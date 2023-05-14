using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [CreateAssetMenu(fileName = "ChangeAnimationBasedOnChaseRageDistanceConditionAction", menuName = "Ai/Action/ChangeAnimationBasedOnChaseRageDistanceConditionAction")]
    public class ChangeAnimationBasedOnChaseRageDistanceConditionAction : ChangeAnimationBasedOnDistanceConditionAction
    {
        protected override float GetDistance(AiContextMdl aiContextMdl)
        {
            
            return aiContextMdl.aiConfig.ChasingDistance;
        }
    }
}