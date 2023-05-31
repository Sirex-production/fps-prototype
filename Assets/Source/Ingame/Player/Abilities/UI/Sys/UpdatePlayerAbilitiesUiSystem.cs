using Entitas;
using Ingame.ConfigProvision;

namespace Ingame.Player.Abilities.UI
{
	public sealed class UpdatePlayerAbilitiesUiSystem : IExecuteSystem
	{
		private readonly PlayerConfig _playerConfig;

		public UpdatePlayerAbilitiesUiSystem(ConfigProvider configProvider)
		{
			_playerConfig = configProvider.playerConfig;
		}
		
		public void Execute()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			
			if(!gameplayContext.hasUiPlayerAbilitiesViewMdl || !gameplayContext.hasPlayerCmp)
				return;

			var playerEntity = gameplayContext.playerCmpEntity;
			var uiPlayerAbilitiesView = gameplayContext.uiPlayerAbilitiesViewMdl.abilitiesView;

			uiPlayerAbilitiesView.SetMagnetAbilityActiveness(gameplayContext.hasIsMagnetActiveTag && gameplayContext.hasMagnetCmp);
			
			if(playerEntity.hasDashingCmp)
			{
				var dashingCmp = playerEntity.dashingCmp;
				float timeLeft = playerEntity.hasIsDashingTag ? 0f : dashingCmp.timePassedSinceLastDash;

				uiPlayerAbilitiesView.SetCooldown
				(
					UiPlayerAbilitiesView.AbilityDisplayType.Dash,
					timeLeft,
					_playerConfig.DashCooldown
				);
			}

			if(playerEntity.hasSlidingCmp)
			{
				var slidingCmp = playerEntity.slidingCmp;

				uiPlayerAbilitiesView.SetCooldown
				(
					UiPlayerAbilitiesView.AbilityDisplayType.Slide,
					slidingCmp.timePassedSinceLastSlide,
					_playerConfig.SlidingCooldown
				);
			}
		}
	}
}