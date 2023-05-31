using System.Runtime.CompilerServices;
using Ingame.Ai.Cmp;
using Ingame.Player;
using UnityEngine;

namespace Ingame.Ai.FSM.Cond
{
    [CreateAssetMenu(fileName = "IsNotVisibleCondition", menuName = "Ai/Cond/IsNotVisibleCondition")]
    public class IsNotVisibleCondition : ConditionBase
    {
        [SerializeField] private bool negate;
        private readonly RaycastHit[] _raycastHits = new RaycastHit[16];
        public override bool Predicate(AiContextMdl aiContextMdl)
        {
            if (aiContextMdl.aiConfig.AttackRange < Vector3.Distance(aiContextMdl.player.position,
                    aiContextMdl.navMeshAgent.transform.position))
                return false;

            var result = IsVisible(ref aiContextMdl);
            return negate ? !result : result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsVisible(ref AiContextMdl aiContextMdl)
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