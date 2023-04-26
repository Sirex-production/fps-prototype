using Entitas;
using Ingame.ConfigProvision;
using UnityEngine;

namespace Ingame.Camerawork.Recoil
{
	public sealed class UpdateCameraRecoilSystem : IExecuteSystem
	{
		private readonly CameraworkConfig _cameraworkConfig;
		private readonly IGroup<GameplayEntity> _weaponInHandsGroup;

		public UpdateCameraRecoilSystem(ConfigProvider configProvider)
		{
			var weaponInHandsMatcher = GameplayMatcher
				.AllOf
				(
					GameplayMatcher.RecoilCmp,
					GameplayMatcher.InHangsTag
				);

			_cameraworkConfig = configProvider.cameraworkConfig;
			_weaponInHandsGroup = Contexts.sharedInstance.gameplay.GetGroup(weaponInHandsMatcher);
		}

		public void Execute()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;

			if(!gameplayContext.hasHudRecoilCmp)
				return;

			var hudRecoilCmp = gameplayContext.hudRecoilCmp;
			
			if(gameplayContext.hasShotPerformedEvent)
			{
				var weaponInHandsEntity = _weaponInHandsGroup.GetSingleEntity();
				var recoilCmp = weaponInHandsEntity.recoilCmp;

				hudRecoilCmp.currentRecoilOffset += recoilCmp.cameraRecoilStrength;
				
				return;
			}

			hudRecoilCmp.currentRecoilOffset = Vector2.Lerp
			(
				hudRecoilCmp.currentRecoilOffset,
				Vector2.zero,
				1f - Mathf.Pow(_cameraworkConfig.RecoilStabilizationDumping, Time.deltaTime)
			);
		}
	}
}