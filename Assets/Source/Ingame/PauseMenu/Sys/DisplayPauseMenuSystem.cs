using Entitas;

namespace Ingame.PauseMenu
{
	public sealed class DisplayPauseMenuSystem : IExecuteSystem
	{
		public void Execute()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			var appContext = Contexts.sharedInstance.app;

			if(!gameplayContext.hasUiPauseMenuModel)
				return;

			if(!gameplayContext.hasPlayerCmp)
				return;

			var playerEntity = gameplayContext.playerCmpEntity;
			var inputCmp = appContext.inputCmp;
			var uiPauseMenu = gameplayContext.uiPauseMenuModel.uiPauseMenu;

			if(!inputCmp.goBackInput)
				return;

			if(uiPauseMenu.IsShown)
			{
				uiPauseMenu.Hide();
				playerEntity.hasIsRotationLockedTag = false;
				playerEntity.hasIsMovementLockedTag = false;

				return;
			}

			uiPauseMenu.Show();
			playerEntity.hasIsRotationLockedTag = true;
			playerEntity.hasIsMovementLockedTag = true;

		}
	}
}