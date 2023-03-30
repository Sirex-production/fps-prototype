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
			var mainCameraMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.CameraMdl,
				GameplayMatcher.MainCameraTag
			);

			_appContext = Contexts.sharedInstance.app;
			_playerGroup = gameplayContext.GetGroup(playerMatcher);
			_mainCameraGroup = gameplayContext.GetGroup(mainCameraMatcher);
		}

		public void Execute()
		{
			var rotationOffset = _appContext.inputCmp.rotateInput * 30f * Time.deltaTime;
			
			var playerEntity = _playerGroup.GetSingleEntity();
			var mainCameraEntity = _mainCameraGroup.GetSingleEntity();
			
			var playerTransform = playerEntity.transformMdl.transform;
			var playerCmp = playerEntity.playerCmp;
			var cameraTransform = mainCameraEntity.transformMdl.transform;
			var targetCameraRotation = cameraTransform.localEulerAngles;

			playerCmp.currentRotationX -= rotationOffset.y;
			playerCmp.currentRotationX = Mathf.Clamp(playerCmp.currentRotationX, -90f, 90f);

			targetCameraRotation.x = playerCmp.currentRotationX;

			cameraTransform.localEulerAngles = targetCameraRotation;
			playerTransform.Rotate(Vector3.up, rotationOffset.x);
		}
	}
}