using Entitas;
using UnityEngine;

namespace Ingame.Ai.Sys
{
    public sealed class FloatFlyingAiSys : IInitializeSystem, IExecuteSystem
    {
        private readonly IGroup<GameplayEntity> _flyingAiGroup;
        public FloatFlyingAiSys()
        {
            var aiMatcher = GameplayMatcher.AllOf(GameplayMatcher.AiContextMdl, GameplayMatcher.FlyingAiCmp,GameplayMatcher.AiModelWrapperContainerMdl);
            _flyingAiGroup = Contexts.sharedInstance.gameplay.GetGroup(aiMatcher);
        }

        
        public void Initialize()
        {
            foreach (var flyingEntity in _flyingAiGroup)
            {
                var flyingCmp = flyingEntity.flyingAiCmp;
                var modelWrapper = flyingEntity.aiModelWrapperContainerMdl.wrapper;
                
                flyingCmp.lastPosition = modelWrapper.position;
            }
        }
        
        public void Execute()
        {
            foreach (var flyingEntity in _flyingAiGroup)
            {
                var aiMdl = flyingEntity.aiContextMdl;
                var flyingCmp = flyingEntity.flyingAiCmp;
                var agentTransform = aiMdl.navMeshAgent.transform;
                var dest = agentTransform.position + agentTransform.up * 3;
                var modelWrapper = flyingEntity.aiModelWrapperContainerMdl.wrapper;
                
                flyingCmp.lastPosition = Vector3.MoveTowards(flyingCmp.lastPosition, dest, Time.deltaTime * 3);
                modelWrapper.position = flyingCmp.lastPosition;
            }
        }
    }
}