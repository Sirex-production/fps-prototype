using Entitas;
using UnityEngine;

namespace Ingame.Ai.Sys
{
    public sealed class FloatFlyingAiSys : IInitializeSystem, IExecuteSystem
    {
        private readonly IGroup<GameplayEntity> _flyingAiGroup;
        public FloatFlyingAiSys()
        {
            var aiMatcher = GameplayMatcher.AllOf(GameplayMatcher.AiContextMdl, GameplayMatcher.FlyingAiCmp);
            _flyingAiGroup = Contexts.sharedInstance.gameplay.GetGroup(aiMatcher);
        }

        
        public void Initialize()
        {
            foreach (var flyingEntity in _flyingAiGroup)
            {
                var AiMdl = flyingEntity.aiContextMdl;
                var body = AiMdl.animator.transform.position;
                var flyingCmp = flyingEntity.flyingAiCmp;

                flyingCmp.lastPosition = body;
            }
        }
        
        public void Execute()
        {
            foreach (var flyingEntity in _flyingAiGroup)
            {
                var AiMdl = flyingEntity.aiContextMdl;
                var transform = AiMdl.animator.transform;
                var body = transform.position;
                var flyingCmp = flyingEntity.flyingAiCmp;

                var hit = Physics.Raycast(AiMdl.weapon.position, -AiMdl.weapon.up, out var raycast, 25f);
                if (hit)
                {
                    var point = raycast.point;
                    var heightDiff = body.y - point.y;
                    if (heightDiff > 3.2f)
                    {
                        var desiredPosition = point + Vector3.up * 3;
                        point.x = body.x;
                        point.z = body.z;
                        
                        //go down
                        var desiredPath = Vector3.MoveTowards(flyingCmp.lastPosition, desiredPosition, 0.3f);
                        var d = Vector3.Slerp(flyingCmp.lastPosition,desiredPath, 0.1f);
                        transform.position = d;

                    }else if (heightDiff < 2.8f)
                    {
                        var desiredPosition = point + Vector3.up * (3-heightDiff);
                        point.x = body.x;
                        point.z = body.z;
                        
                        //go up
                        var desiredPath = Vector3.MoveTowards(flyingCmp.lastPosition, desiredPosition, 0.3f);
                        var d = Vector3.Slerp(flyingCmp.lastPosition,desiredPath, 0.1f);
                        transform.position = d;
                    }
                }
            }
        }

      
    }
}