using Entitas;
using Ingame.Camerawork;
using Ingame.ConfigProvision;
using UnityEngine;

namespace Ingame.Gunplay.EnergyGun
{
	public sealed class ZoomAimWithEnergyRifleSystem : IExecuteSystem
	{
		private readonly CameraworkConfig _cameraworkConfig;
		
		public ZoomAimWithEnergyRifleSystem(ConfigProvider configProvider)
		{
			_cameraworkConfig = configProvider.cameraworkConfig;
		}
		
		public void Execute()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			var appContext = Contexts.sharedInstance.app;

			if(!gameplayContext.hasMainVirtualCameraTag || !gameplayContext.hasHudCameraTag || !gameplayContext.hasEnergyGunCmp ||!appContext.hasInputCmp)
				return;

			var mainVCameraEntity = gameplayContext.mainVirtualCameraTagEntity;
			var hudCameraEntity = gameplayContext.hudCameraTagEntity;

			if(!mainVCameraEntity.hasCinemachineVirtualCameraMdl || !hudCameraEntity.hasCameraMdl)
				return;

			var inputCmp = appContext.inputCmp;
			var energyRifleEntity = gameplayContext.energyGunCmpEntity;
			var energyRifleCmp = energyRifleEntity.energyGunCmp;
			var mainVCamera = mainVCameraEntity.cinemachineVirtualCameraMdl.virtualCamera;
			var hudCamera = hudCameraEntity.cameraMdl.camera;

			float targetCameraFov = inputCmp.aimHoldInput && energyRifleEntity.hasInHangsTag ? energyRifleCmp.cameraAimFov : _cameraworkConfig.DefaultCameraFov;
			float targetHudCameraFov = inputCmp.aimHoldInput && energyRifleEntity.hasInHangsTag ? energyRifleCmp.hudCameraAimFov : _cameraworkConfig.DefaultHudCameraFov;

			mainVCamera.m_Lens.FieldOfView = Mathf.Lerp
			(
				mainVCamera.m_Lens.FieldOfView,
				targetCameraFov,
				1f - Mathf.Pow(energyRifleCmp.aimDumping, Time.deltaTime)
			);
			
			hudCamera.fieldOfView = Mathf.Lerp
			(
				mainVCamera.m_Lens.FieldOfView,
				targetHudCameraFov,
				1f - Mathf.Pow(energyRifleCmp.aimDumping, Time.deltaTime)
			);
		}
	}
}