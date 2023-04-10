using Entitas;

namespace Ingame.Effects.UI
{
	public sealed class UpdatePlayerStatsUiSystem : IExecuteSystem
	{
		public void Execute()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			
			if(!gameplayContext.hasUiPlayerStatsViewMdl || !gameplayContext.hasPlayerCmp)
				return;

			var playerEntity = gameplayContext.playerCmpEntity;
			
			if(!playerEntity.hasHealthCmp || !playerEntity.hasArmorCmp)
				return;

			var healthCmp = playerEntity.healthCmp;
			var armorCmp = playerEntity.armorCmp;

			var uiPlayerStatsView = gameplayContext.uiPlayerStatsViewMdl.uiPlayerStatsView;

			uiPlayerStatsView.SetStat(UiPlayerStatsView.DisplayStatType.Health, healthCmp.currentHealth, healthCmp.maximumHealth);
			uiPlayerStatsView.SetStat(UiPlayerStatsView.DisplayStatType.Armor, armorCmp.currentArmor, armorCmp.maximumArmor);
		}
	}
}