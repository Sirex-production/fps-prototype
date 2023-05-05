using Entitas;
using UnityEngine;

namespace Ingame.Player.Movement
{
	public sealed class RotatePlayerSys : IExecuteSystem
	{
		private readonly AppContext _appContext;
		private readonly IGroup<GameplayEntity> _playerGroup;
		private readonly IGroup<GameplayEntity> _hudOriginGroup;

		public RotatePlayerSys()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			var playerMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.TransformMdl,
				GameplayMatcher.PlayerCmp
			);
			var hudOriginMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.TransformMdl,
				GameplayMatcher.HudOriginCmp
			);

			_appContext = Contexts.sharedInstance.app;
			_playerGroup = gameplayContext.GetGroup(playerMatcher);
			_hudOriginGroup = gameplayContext.GetGroup(hudOriginMatcher);
		}

		public void Execute()
		{
			var settingsData = _appContext.settingsCmp.currentSettingsData;
			var rotationOffset = _appContext.inputCmp.rotateInput * settingsData.sensitivity * Time.deltaTime;
			
			var playerEntity = _playerGroup.GetSingleEntity();
			var hudOriginEntity = _hudOriginGroup.GetSingleEntity();

			if(playerEntity.hasIsRotationLockedTag)
				return;
			
			var playerTransform = playerEntity.transformMdl.transform;
			var hudOriginCmp = hudOriginEntity.hudOriginCmp;
			var hudOriginTransform = hudOriginEntity.transformMdl.transform;
			var targetHudOriginRotation = hudOriginTransform.localEulerAngles;

			hudOriginCmp.currentRotationX -= rotationOffset.y;
			hudOriginCmp.currentRotationX = Mathf.Clamp(hudOriginCmp.currentRotationX, -90f, 90f);

			targetHudOriginRotation.x = hudOriginCmp.currentRotationX;

			hudOriginTransform.localEulerAngles = targetHudOriginRotation;
			playerTransform.Rotate(Vector3.up, rotationOffset.x);
		}
	}
}