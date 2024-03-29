﻿using Entitas;
using UnityEngine;


namespace Ingame.Ai.Sys
{
    public sealed class RunStateMachineSys : IInitializeSystem,IExecuteSystem
    {
        private readonly IGroup<GameplayEntity> _stateMachineGroup;
        private readonly IGroup<GameplayEntity> _playerGroup;

        private Transform _player;
        private Collider _playerCollider;


        public RunStateMachineSys() : this(Contexts.sharedInstance.gameplay)
        {
            
        }
        
        public RunStateMachineSys(IContext<GameplayEntity> context)
        {
            var aiMatcher = GameplayMatcher.AllOf(GameplayMatcher.AiContextMdl);
            _stateMachineGroup = context.GetGroup(aiMatcher);
            
            var playerMatcher = GameplayMatcher.AllOf(GameplayMatcher.PlayerCmp, GameplayMatcher.TransformMdl);
            _playerGroup = context.GetGroup(playerMatcher);
        }
        
        public void Initialize()
        {
            var playerEntity = _playerGroup.GetSingleEntity();
            _player = playerEntity.transformMdl.transform;
            _playerCollider = _player.GetComponentInChildren<Collider>();
                
            foreach (var aiEntity in _stateMachineGroup)
            {
                var aiContent = aiEntity.aiContextMdl;
                
                aiContent.player = _player;
                aiContent.playerCollider = _playerCollider;
                
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