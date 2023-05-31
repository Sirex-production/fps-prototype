using Ingame.Ai.Cmp;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ingame.Ai.FSM.Cond
{
    [CreateAssetMenu(fileName = "AngleCondition", menuName = "Ai/Cond/Angle")]
    public sealed class AngleCondition : ConditionBase
    { 
        private float _angle;
        private bool _isCashed;
        
        public override bool Predicate(AiContextMdl aiContextMdl)
        {
            if (!_isCashed)
            {
                _angle = aiContextMdl.aiConfig.DetectionAngle;
                _isCashed = true;
            }

            var agentTransform = aiContextMdl.navMeshAgent.transform;
            var dir = aiContextMdl.player.position - agentTransform.position;
            dir.y = 0;
            
            var deltaAngle = Vector3.Angle(dir, agentTransform.forward);
           
            return !(deltaAngle >= _angle || deltaAngle < 0);
        }
    }
}