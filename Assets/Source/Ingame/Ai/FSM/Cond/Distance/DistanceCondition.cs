using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Cond
{
    public abstract class DistanceCondition : ConditionBase
    {
        private enum DistanceOperator
        {
            Smaller,
            Bigger
        }
        
        [SerializeField] 
        private DistanceOperator distanceOperator;
        
        protected float distance;

        private bool _isInit;
        protected abstract void InitDistance(AiContextMdl aiContextMdl);
        
        public override bool Predicate(AiContextMdl aiContextMdl)
        {
            if (!_isInit)
            {
                InitDistance(aiContextMdl);
                _isInit = true;
            }
            
            float dist = Vector3.Distance(aiContextMdl.player.transform.position, aiContextMdl.navMeshAgent.transform.position);
           
            return distanceOperator == DistanceOperator.Bigger ? dist > distance : dist < distance;
        }
    }
}