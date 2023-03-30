using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Cond
{
    [CreateAssetMenu(fileName = "DistanceCondition", menuName = "Ai/Cond/Distance")]
    public sealed class DistanceCondition : ConditionBase
    {
        private enum DistanceOperator
        {
            Smaller,
            Bigger
        }
        
        [SerializeField]
        [Min(0)]
        private float distance;

        [SerializeField] 
        private DistanceOperator distanceOperator;
        
        public override bool Predicate(AiContextMdl aiContextMdl)
        {
            float dist = Vector3.Distance(aiContextMdl.player.transform.position, aiContextMdl.navMeshAgent.transform.position);
           
            return distanceOperator == DistanceOperator.Bigger ? dist > distance : dist < distance;
        }
    }
}