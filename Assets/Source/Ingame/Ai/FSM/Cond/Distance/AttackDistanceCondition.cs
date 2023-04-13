using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Cond
{
    [CreateAssetMenu(fileName = "AttackDistanceCondition", menuName = "Ai/Cond/Distance/AttackDistanceCondition")]
    public sealed class AttackDistanceCondition : DistanceCondition
    {
     
        protected override float GetDistance(AiContextMdl aiContextMdl)
        {
            return aiContextMdl.aiConfig.AttackVisionRange;
        }
    }
}