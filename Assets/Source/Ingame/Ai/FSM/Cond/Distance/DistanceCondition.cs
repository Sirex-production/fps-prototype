using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Cond
{
    public enum DistanceOperator
    {
        Smaller,
        Bigger
    }
    public abstract class DistanceCondition : ConditionBase
    {
      
        
        [SerializeField] 
        private DistanceOperator distanceOperator;
        
        private bool _isInit;

        protected abstract float GetDistance(AiContextMdl aiContextMdl);

        public override bool Predicate(AiContextMdl aiContextMdl)
        {
            float dist = Vector3.Distance(aiContextMdl.player.transform.position, aiContextMdl.animator.transform.position);
            float dist2 = GetDistance(aiContextMdl);
            return distanceOperator == DistanceOperator.Bigger ? dist > dist2 : dist <= dist2;
        }
    }
}