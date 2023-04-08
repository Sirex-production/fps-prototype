using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Cond
{
    [CreateAssetMenu(fileName = "ChaseDistanceCondition", menuName = "Ai/Cond/Distance/ChaseDistanceCondition")]
    public sealed class ChaseDistanceCondition : DistanceCondition
    {
        protected override void InitDistance(AiContextMdl aiContextMdl)
        {
            distance = aiContextMdl.aiConfig.ChasingDistance;
        }
    }
}