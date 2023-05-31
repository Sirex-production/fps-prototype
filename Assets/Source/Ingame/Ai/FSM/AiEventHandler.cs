using System.Collections.Generic;
using System.Runtime.CompilerServices;
using EcsSupport.UnityIntegration;
using Ingame.Ai.Cmp;
using Ingame.Ai.FSM.AiAttackConfig;
using Ingame.Player;
using NaughtyAttributes;
using UnityEngine;

namespace Ingame.Ai.FSM
{

    public class AiEventHandler : MonoBehaviour
    {
        [Required] 
        [SerializeField]
        private AiAttackBaseConfig attackPattern;

        [Required]
        [SerializeField]
        private AiBaker aiBaker;
        
        private readonly Dictionary<string, int> _cashedAnimationToHash = new ();
        private readonly RaycastHit[] _raycastHits = new RaycastHit[16];
        private Animator _animator;
        private void Awake()
        {
            _animator = aiBaker.Animator;
        }

        private void ReleaseAnimation(string animationName)
        {
            if(!_cashedAnimationToHash.ContainsKey(animationName))
                _cashedAnimationToHash.Add(animationName, Animator.StringToHash(animationName));
            
            _animator.SetBool(_cashedAnimationToHash[animationName], false);
        }

        private void Attack()
        {
            attackPattern.Attack(aiBaker);
        }

        protected void Die()
        {
            var colliders = GetComponentsInChildren<Collider>();
            foreach (var c in colliders)
            {
                c.enabled = false;
            }
        }

        
        private void LookAt()
        {
            Vector3 rotation = Quaternion.LookRotation( -aiBaker.NavMeshAgent.transform.position+aiBaker.Entity.aiContextMdl.player.position).eulerAngles;
            rotation.x = 0f;
            rotation.z = 0f;
            
            aiBaker.NavMeshAgent.transform.rotation  = Quaternion.Euler(rotation);
        }
        
        private void ReleaseAnimationIfOutOfRange(string animationName)
        {
            var distance = Vector3.Distance(aiBaker.NavMeshAgent.transform.position, aiBaker.Entity.aiContextMdl.player.position);
            if (distance < aiBaker.AIConfig.AttackVisionRange)
                return;

            ReleaseAnimation(animationName);
        }
        
        private void ReleaseAnimationIfTargetNotVisible(string animationName)
        {
            if(!IsVisible(aiBaker.Entity.aiContextMdl));
                ReleaseAnimation(animationName);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsVisible(AiContextMdl aiContextMdl)
        {
            var position = aiContextMdl.navMeshAgent.transform.position;
            var playerPosition = aiContextMdl.player.position;
            var dir = ( position-playerPosition).normalized;
            var dist = Vector3.Distance(position, playerPosition);
            
            var hitNonAlloc = Physics.RaycastNonAlloc(position, dir, _raycastHits,dist);

            if (hitNonAlloc<=0)
                return false;

            for (int i = 0; i < hitNonAlloc; i++)
            {
                var root = _raycastHits[i].collider.transform.root;
                if(root.TryGetComponent<PlayerBaker>(out var player ) || root.TryGetComponent<AiBaker>(out var enemy))
                    continue;

                return true;
            }

            return false;
        }
    }
}