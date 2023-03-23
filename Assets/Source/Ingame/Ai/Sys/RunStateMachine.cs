using Entitas;

namespace Ingame.Ai.Sys
{
    public sealed class RunStateMachine : IExecuteSystem
    {
        private readonly IGroup<GameplayEntity> _stateMachineGroup;
		
        public RunStateMachine()
        {
            var gameplayContext = Contexts.sharedInstance.gameplay;
            var aiMatcher = GameplayMatcher.AllOf(GameplayMatcher.AiContextMdl);

            _stateMachineGroup = gameplayContext.GetGroup(aiMatcher);
        }
        
        public void Execute()
        {
            foreach (var aiEntity in _stateMachineGroup)
            {
                var aiContent = aiEntity.aiContextMdl;
                aiContent.curentState = aiContent.curentState.Tick(aiContent);
            }
        }
    }
}