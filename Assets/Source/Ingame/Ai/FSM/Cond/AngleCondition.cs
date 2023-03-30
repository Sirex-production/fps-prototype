using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Cond
{
    [CreateAssetMenu(fileName = "AngleCondition", menuName = "Ai/Cond/Angle")]
    public sealed class AngleCondition : ConditionBase
    {
        [SerializeField] [Min(0)] private float angle;
        public override bool Predicate(AiContextMdl aiContextMdl)
        {
            var agentTransform = aiContextMdl.navMeshAgent.transform;
            var dir = aiContextMdl.player.position - agentTransform.position;
            dir.y = 0;
            
            var deltaAngle = Vector3.Angle(dir, agentTransform.forward);
           
            return !(deltaAngle >= angle || deltaAngle < 0);
        }
    }
}