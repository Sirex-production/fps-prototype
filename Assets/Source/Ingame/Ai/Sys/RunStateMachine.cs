using Entitas;
using UnityEngine;


namespace Ingame.Ai.Sys
{
    public sealed class RunStateMachine : IInitializeSystem,IExecuteSystem
    {
        private readonly IGroup<GameplayEntity> _stateMachineGroup;
        private readonly IGroup<GameplayEntity> _playerGroup;

        private Transform _player;

        public RunStateMachine()
        {
            var gameplayContext = Contexts.sharedInstance.gameplay;
            
            var aiMatcher = GameplayMatcher.AllOf(GameplayMatcher.AiContextMdl);
            _stateMachineGroup = gameplayContext.GetGroup(aiMatcher);
            
            var playerMatcher = GameplayMatcher.AllOf(GameplayMatcher.PlayerCmp, GameplayMatcher.TransformMdl);
            _playerGroup = gameplayContext.GetGroup(playerMatcher);
        }
        
        public void Initialize()
        {
            var playerEntity = _playerGroup.GetSingleEntity();
            _player = playerEntity.transformMdl.transform;
            
            foreach (var aiEntity in _stateMachineGroup)
            {
                var aiContent = aiEntity.aiContextMdl;
                aiContent.player = _player;
                
                ref var stateWrapper = ref aiContent.aiStateWrapper;
                stateWrapper.currentState = aiContent.aiConfig.InitState;
            }
        }
        
        public void Execute()
        {
            foreach (var aiEntity in _stateMachineGroup)
            {
                var aiContent = aiEntity.aiContextMdl;
                ref var stateWrapper = ref aiContent.aiStateWrapper;
        
                stateWrapper.currentState = stateWrapper.currentState.Tick(aiContent);
            }
        }
    }
}