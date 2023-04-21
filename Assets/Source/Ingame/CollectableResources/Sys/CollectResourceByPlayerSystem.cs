using DG.Tweening;
using EcsSupport.Extensions;
using Entitas;
using Ingame.ConfigProvision;
using UnityEngine;

namespace Ingame.CollectableResources
{
	public sealed class CollectResourceByPlayerSystem : IExecuteSystem
	{
		private readonly CollectableResourcesConfig _resourcesConfig;
		
		private readonly IGroup<GameplayEntity> _collectableResourceGroup;
		private readonly IGroup<GameplayEntity> _playerGroup;

		public CollectResourceByPlayerSystem(ConfigProvider configProvider)
		{
			var collectableResource = GameplayMatcher.AnyOf
			(
				GameplayMatcher.CollectableArmorCmp,
				GameplayMatcher.CollectableHealthCmp
			);

			var playerMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.PlayerCmp,
				GameplayMatcher.HealthCmp
			);

			_resourcesConfig = configProvider.collectableResourcesConfig;
			_collectableResourceGroup = Contexts.sharedInstance.gameplay.GetGroup(collectableResource);
			_playerGroup = Contexts.sharedInstance.gameplay.GetGroup(playerMatcher);
		}
		
		public void Execute()
		{
			if(_playerGroup.IsEmpty())
				return;

			var playerEntity = _playerGroup.GetSingleEntity();
			var playerTransform = playerEntity.transformMdl.transform;

			foreach(var resourceEntity in _collectableResourceGroup.GetEntities())
			{
				if(!resourceEntity.hasTransformMdl)
					continue;

				var resourceTransform = resourceEntity.transformMdl.transform;

				if(Vector3.Distance(resourceTransform.position, playerTransform.position) > _resourcesConfig.InteractionDistance)
					continue;

				AddResource(resourceEntity, playerEntity);
				DestroyResourceEntity(resourceEntity);
			}
		}

		private void AddResource(GameplayEntity resourceEntity, GameplayEntity playerEntity)
		{
			if(resourceEntity.hasCollectableArmorCmp)
			{
				var collectableArmorCmp = resourceEntity.collectableArmorCmp;
				playerEntity.AddAddArmorCmp(collectableArmorCmp.amountOfCollectableArmor);
				
				resourceEntity.RemoveCollectableArmorCmp();
			}
			
			if(resourceEntity.hasCollectableHealthCmp)
			{
				var collectableHealthCmp = resourceEntity.collectableHealthCmp;
				playerEntity.AddAddHealthCmp(collectableHealthCmp.amountOfCollectableHealth);
				
				resourceEntity.RemoveCollectableHealthCmp();
			}
		}

		private void DestroyResourceEntity(GameplayEntity resourceEntity)
		{
			var resourceTransform = resourceEntity.transformMdl.transform;
			
			resourceTransform.DOScale(Vector3.zero, _resourcesConfig.ResourceConsumptionAnimationDuration)
				.SetLink(resourceTransform.gameObject)
				.OnComplete(() => resourceTransform.gameObject.SetActive(false));
			
			resourceEntity.Destroy();
		}
	}
}