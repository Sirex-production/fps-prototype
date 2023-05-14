using System;
using Ingame.Ai.Cmp;
using Ingame.Ai.FSM.Cond;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    public abstract class ChangeAnimationBasedOnDistanceConditionAction : ConditionAction
    {
        [SerializeField] 
        private DistanceOperator distanceOperator;

        [SerializeField] 
        private string animationParamName;
        
        [SerializeField] 
        private bool boolValue;
        protected abstract float GetDistance(AiContextMdl aiContextMdl);

        private void ChangeBoolParam(AiContextMdl aiContextMdl)
        {
            var animator = aiContextMdl.animator;
            animator.SetBool(animationParamName,boolValue);
        }
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            var dist1 = GetDistance(aiContextMdl);
            var dist2 = Vector3.Distance(aiContextMdl.player.position, aiContextMdl.navMeshAgent.transform.position);
            
            switch (distanceOperator)
            {
                case DistanceOperator.Bigger when dist2 >= dist1:
                case DistanceOperator.Smaller when dist2 < dist1:
                    ChangeBoolParam(aiContextMdl);
                    break;
            }
            
            return ActionStatus.Done;
        }
    }
}