using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Cond
{
    [CreateAssetMenu(fileName = "ChaseDistanceCondition", menuName = "Ai/Cond/Distance/ChaseDistanceCondition")]
    public sealed class ChaseDistanceCondition : DistanceCondition
    {

        protected override float GetDistance(AiContextMdl aiContextMdl)
        {
            return aiContextMdl.aiConfig.ChasingDistance;
        }
    }
}