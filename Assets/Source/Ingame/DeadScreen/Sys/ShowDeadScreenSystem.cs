using System.Collections.Generic;
using Entitas;

namespace Ingame.DeadScreen.Sys
{
	public sealed class ShowDeadScreenSystem : ReactiveSystem<GameplayEntity>
	{
		public ShowDeadScreenSystem(IContext<GameplayEntity> context) : base(context)
		{
			
		}
		
		protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
		{
			return context.CreateCollector(GameplayMatcher.AllOf(GameplayMatcher.PlayerCmp, GameplayMatcher.IsDeadTag));
		}

		protected override bool Filter(GameplayEntity entity)
		{
			return true;
		}

		protected override void Execute(List<GameplayEntity> entities)
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			
			if(!gameplayContext.hasUiDeadScreenMdl)
				return;

			var uiDeadScreen = gameplayContext.uiDeadScreenMdl.uiDeadScreen;
			
			uiDeadScreen.Show();
		}
	}
}