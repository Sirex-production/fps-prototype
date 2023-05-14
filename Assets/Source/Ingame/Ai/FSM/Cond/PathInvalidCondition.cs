using Ingame.Ai.Cmp;
using UnityEngine;
using UnityEngine.AI;

namespace Ingame.Ai.FSM.Cond
{
    [CreateAssetMenu(fileName = "PathInvalidCondition", menuName = "Ai/Cond/PathInvalidCondition")]
    public sealed class PathInvalidCondition : ConditionBase
    {
        public override bool Predicate(AiContextMdl aiContextMdl)
        {
            return aiContextMdl.navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid;
        }
    }
}