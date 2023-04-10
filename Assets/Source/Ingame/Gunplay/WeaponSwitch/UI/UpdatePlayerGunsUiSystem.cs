using Entitas;

namespace Ingame.Gunplay.UI
{
	public sealed class UpdatePlayerGunsUiSystem : IExecuteSystem
	{
		public void Execute()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			
			if(!gameplayContext.hasUiPlayerGunsViewMdl || !gameplayContext.hasWeaponHolderCmp)
				return;
			
			var weaponHolderCmp = gameplayContext.weaponHolderCmp;
			var uiPlayerGunsView = gameplayContext.uiPlayerGunsViewMdl.gunsView;
			
			uiPlayerGunsView.SetActiveGun((UiPlayerGunsView.GunDisplayType)weaponHolderCmp.currentWeaponIndex);
		}
	}
}