using Entitas;
using Ingame.ConfigProvision;
using UnityEngine;

namespace Ingame.Player.Movement
{
	public sealed class ChangePlayerHeightSystem : IExecuteSystem
	{
		private readonly PlayerConfig _playerConfig;
		private readonly GameplayContext _gameplayContext;

		public ChangePlayerHeightSystem(ConfigProvider configProvider)
		{
			_playerConfig = configProvider.playerConfig;
			_gameplayContext = Contexts.sharedInstance.gameplay;
		}

		public void Execute()
		{
			if(!_gameplayContext.hasPlayerCmp)
				return;

			var playerEntity = _gameplayContext.playerCmpEntity;

			if(!playerEntity.hasCharacterControllerMdl)
				return;

			var playerCharacterController = playerEntity.characterControllerMdl.characterController;
			float targetHeight = playerEntity.hasIsSlidingTag ? _playerConfig.PlayerHeightWhileSliding : _playerConfig.DefaultPlayerHeight;

			playerCharacterController.height = Mathf.Lerp
			(
				playerCharacterController.height,
				targetHeight,
				1f - Mathf.Pow(_playerConfig.PlayerHighChangeDumping, Time.deltaTime)
			);
		}
	}
}