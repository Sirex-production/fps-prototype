using Entitas;

namespace Ingame.Player.Abilities.Magnet
{
	public sealed class ActivateMagnetAbilitySystem : IExecuteSystem
	{
		public void Execute()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			
			if(!gameplayContext.hasMagnetCmp)
				return;
			
			var inputCmp = Contexts.sharedInstance.app.inputCmp;

			gameplayContext.hasIsMagnetActiveTag  = inputCmp.magnetAbilityInput;
		}
	}
}