using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Cond
{
    [CreateAssetMenu(fileName = "SuccessConditionConfig", menuName = "Ai/Cond/Success")]
    public sealed class SuccessCondition : ConditionBase
    {
        public override bool Predicate(AiContextMdl aiContextMdl)
        {
            return true;
        }
    }
}