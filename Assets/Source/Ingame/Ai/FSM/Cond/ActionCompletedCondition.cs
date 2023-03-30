using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Cond
{
    [CreateAssetMenu(fileName = "ActionCompletedCondition", menuName = "Ai/Cond/ActionCompletedCondition")]
    public sealed class ActionCompletedCondition : ConditionBase
    {
        public override bool Predicate(AiContextMdl aiContextMdl)
        {
            return !aiContextMdl.aiStateWrapper.isActionStarted;
        }
    }
}