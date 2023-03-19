using Entitas;
using UnityEngine;

namespace Ingame.Player.Movement
{
	public sealed class RotatePlayerSys : IExecuteSystem
	{
		private readonly AppContext _appContext;
		private readonly IGroup<GameplayEntity> _playerGroup;
		private readonly IGroup<GameplayEntity> _mainCameraGroup;

		public RotatePlayerSys()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			var playerMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.TransformMdl,
				GameplayMatcher.PlayerCmp
			);
			var cameraMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.CameraMdl,
				GameplayMatcher.MainCameraTag
			);

			_appContext = Contexts.sharedInstance.app;
			_playerGroup = gameplayContext.GetGroup(playerMatcher);
			_mainCameraGroup = gameplayContext.GetGroup(cameraMatcher);
		}

		public void Execute()
		{
			var rotateInput = _appContext.inputCmp.rotateInput;
			
			var playerEntity = _playerGroup.GetSingleEntity();
			var mainCameraEntity = _mainCameraGroup.GetSingleEntity();
			
			var playerTransform = playerEntity.transformMdl.transform;
			var cameraTransform = mainCameraEntity.transformMdl.transform;
			
			playerTransform.Rotate(Vector3.up, rotateInput.x * 30f * Time.deltaTime);
			cameraTransform.Rotate(Vector3.right, -rotateInput.y *  30f * Time.deltaTime);
		}
	}
}