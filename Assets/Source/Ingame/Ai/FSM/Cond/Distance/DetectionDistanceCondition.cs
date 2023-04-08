using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Cond
{
    [CreateAssetMenu(fileName = "DetectionDistanceCondition", menuName = "Ai/Cond/Distance/DetectionDistanceCondition")]
    public sealed class DetectionDistanceCondition : DistanceCondition
    {
        protected override void InitDistance(AiContextMdl aiContextMdl)
        {
            distance = aiContextMdl.aiConfig.DetectionRange;
        }
    }
}