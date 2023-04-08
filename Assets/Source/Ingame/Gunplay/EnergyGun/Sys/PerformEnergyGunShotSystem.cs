using Entitas;
using UnityEngine;

namespace Ingame.Gunplay.EnergyGun
{
	public sealed class PerformEnergyGunShotSystem : IExecuteSystem
	{
		private const float LINE_RENDERER_OFFSET = 2f;
		private static readonly int RAYCAST_LAYER_MASK = ~LayerMask.GetMask("Player", "Hud", "Ignore Raycast");

		public void Execute()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;

			if(!gameplayContext.hasEnergyGunCmp || !gameplayContext.hasMainCameraTag)
				return;

			var inputCmp = Contexts.sharedInstance.app.inputCmp;
			var mainCameraEntity = gameplayContext.mainCameraTagEntity;
			var energyGunEntity = gameplayContext.energyGunCmpEntity;
			var energyGunCmp = energyGunEntity.energyGunCmp;

			energyGunCmp.timePassedSinceLastShot += Time.deltaTime;
			
			if(!inputCmp.shootTapInput || !mainCameraEntity.hasCameraMdl)
				return;
			
			if(!energyGunEntity.hasInHangsTag || energyGunCmp.timePassedSinceLastShot < energyGunCmp.cooldownBetweenShots)
				return;

			energyGunCmp.timePassedSinceLastShot = 0f;
			
			gameplayContext.hasShotPerformedEvent = true;

			var mainCamera = mainCameraEntity.cameraMdl.camera;
			var raycastRay = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

			if(!Physics.Raycast(raycastRay, out RaycastHit hit, 999f, RAYCAST_LAYER_MASK, QueryTriggerInteraction.Ignore))
				return;

			DrawShotTrail(gameplayContext, energyGunEntity, hit.point);
		}

		private void DrawShotTrail(GameplayContext gameplayContext, GameplayEntity energyGunEntity, Vector3 hitPos)
		{
			if(!energyGunEntity.hasLineRendererMdl || !energyGunEntity.hasTransformMdl)
				return;

			var lineRendererMdl = energyGunEntity.lineRendererMdl;	
			var energyGunTransform = energyGunEntity.transformMdl.transform;
			var statPos = energyGunTransform.position + energyGunTransform.forward * LINE_RENDERER_OFFSET;
			var lineRendererPositions = new[] { statPos, hitPos };

			gameplayContext.CreateEntity().AddShotTrailCmp(lineRendererMdl.lineRenderer, lineRendererPositions, .5f, 0f);
		}
	}
}