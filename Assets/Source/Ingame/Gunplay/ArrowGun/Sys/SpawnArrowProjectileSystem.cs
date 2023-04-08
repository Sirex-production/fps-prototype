using EcsSupport.Extensions;
using Entitas;
using Ingame.Gunplay.Sway;
using UnityEngine;
using Zenject;

namespace Ingame.Gunplay.ArrowGun
{
	public sealed class SpawnArrowProjectileSystem : IExecuteSystem
	{
		private DiContainer _diContainer;
		
		private readonly IGroup<GameplayEntity> _arrowSpawnerGroup;
		private readonly IGroup<GameplayEntity> _freeToReuseArrows;

		public SpawnArrowProjectileSystem(DiContainer diContainer)
		{
			_diContainer = diContainer;

			var arrowSpawnerMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.ArrowSpawnerCmp,
				GameplayMatcher.InHangsTag
			);
			var freeArrowSpawner = GameplayMatcher.AllOf
			(
				GameplayMatcher.ArrowCmp,
				GameplayMatcher.FreeToReuseTag
			);

			_arrowSpawnerGroup = Contexts.sharedInstance.gameplay.GetGroup(arrowSpawnerMatcher);
			_freeToReuseArrows = Contexts.sharedInstance.gameplay.GetGroup(freeArrowSpawner);
		}

		public void Execute()
		{
			var inputCmp = Contexts.sharedInstance.app.inputCmp;

			foreach(var entity in _arrowSpawnerGroup)
			{
				var arrowSpawnerCmp = entity.arrowSpawnerCmp;

				arrowSpawnerCmp.timePassedSinceLastShot += Time.deltaTime;

				if(!inputCmp.shootHoldInput)
					return;
				
				if(arrowSpawnerCmp.timePassedSinceLastShot < arrowSpawnerCmp.pauseBetweenShots)
					return;

				arrowSpawnerCmp.timePassedSinceLastShot = 0f;
				
				var arrowProjectileEntity = GetArrowProjectileEntity(arrowSpawnerCmp);
				var arrowTransform = arrowProjectileEntity.transformMdl.transform;

				arrowTransform.position = arrowSpawnerCmp.spawnOriginTransform.position;
				arrowTransform.rotation = arrowSpawnerCmp.spawnOriginTransform.rotation;
				arrowTransform.gameObject.SetActive(true);
				
				if(!Contexts.sharedInstance.gameplay.hasShotPerformedEvent)
					Contexts.sharedInstance.gameplay.hasShotPerformedEvent = true;
			}
		}

		private GameplayEntity GetArrowProjectileEntity(ArrowSpawnerCmp arrowSpawnerCmp)
		{
			if(_freeToReuseArrows.IsEmpty())
				return _diContainer.InstantiatePrefab(arrowSpawnerCmp.arrowProjectilePrefab)
									.GetComponent<ArrowProjectileBaker>()
									.GameplayEntityReference
									.attachedEntity;

			var arrowEntity = _freeToReuseArrows.GetFirstEntity();
			arrowEntity.hasFreeToReuseTag = false;

			return arrowEntity;
		}
	}
}