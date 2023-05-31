using Ingame.DeadScreen.Sys;

namespace Ingame.DeadScreen
{
	public sealed class DeadScreenFeature : Feature
	{
		public DeadScreenFeature()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			
			Add(new ShowDeadScreenSystem(gameplayContext));
		}
	}
}