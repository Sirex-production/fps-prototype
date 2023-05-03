using System.Collections.Generic;
using EcsSupport.UnityIntegration;
using Ingame.Ai.FSM.AiAttackConfig;
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
           
        }

        private void LookAt()
        {
            aiBaker.NavMeshAgent.transform.LookAt(aiBaker.Entity.aiContextMdl.player);
        }
        
        
        private void ReleaseAnimationIfOutOfRange(string animationName)
        {
            var distance = Vector3.Distance(aiBaker.NavMeshAgent.transform.position, aiBaker.Entity.aiContextMdl.player.position);
            if (distance < aiBaker.AIConfig.AttackVisionRange)
                return;

            ReleaseAnimation(animationName);
        }
    }
}