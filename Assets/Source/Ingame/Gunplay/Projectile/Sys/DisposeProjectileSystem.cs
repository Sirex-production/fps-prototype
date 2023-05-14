using EcsSupport.UnityIntegration;
using EcsSupport.UnityIntegration.Physics;
using Entitas;
using UnityEngine;

namespace Ingame.Gunplay.Projectile
{
	public sealed class DisposeProjectileSystem : IExecuteSystem
	{
		private readonly IGroup<GameplayEntity> _projectileGroup;
		private readonly IGroup<GameplayEntity> _physicsEventsGroup;

		public DisposeProjectileSystem()
		{
			var projectileMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.TransformMdl,
				GameplayMatcher.ProjectileCmp
			);

			var physicsEventMatcher = GameplayMatcher.AnyOf
			(
				GameplayMatcher.OnCollisionEnterEvent,
				GameplayMatcher.OnTriggerEnterEvent
			);

			_projectileGroup = Contexts.sharedInstance.gameplay.GetGroup(projectileMatcher);
			_physicsEventsGroup = Contexts.sharedInstance.gameplay.GetGroup(physicsEventMatcher);
		}

		public void Execute()
		{
			foreach(var physicsEventEntity in _physicsEventsGroup)
			{
				if(physicsEventEntity.hasOnCollisionEnterEvent)
					ProcessOnCollisionEnterEvent(physicsEventEntity.onCollisionEnterEvent);
				
				ProcessOnTriggerEnterEvent(physicsEventEntity.onTriggerEnterEvent);
			}
		}

		private void ProcessOnCollisionEnterEvent(OnCollisionEnterEvent onCollisionEnterEvent)
		{
			var otherCollisionEventGameObject = onCollisionEnterEvent.other.gameObject;
			var senderCollisionEventGameObject = onCollisionEnterEvent.sender.gameObject;
			
			foreach(var projectileEntity in _projectileGroup)
			{
				if(projectileEntity.hasFreeToReuseTag)
					continue;
				
				var projectileGameObject = projectileEntity.transformMdl.transform.gameObject;
				
				if(otherCollisionEventGameObject != projectileGameObject && senderCollisionEventGameObject != projectileGameObject)
					continue;

				projectileGameObject.SetActive(false);
				projectileEntity.hasFreeToReuseTag = true;
				
				if (!otherCollisionEventGameObject.TryGetComponent<GameplayEntityReference>(out var entityReference))
					continue;
				
				if(entityReference.attachedEntity.hasHealthCmp)
					Contexts.sharedInstance.gameplay.CreateEntity().AddTakeDamageReq(12,entityReference.attachedEntity);
			}
		}

		private void ProcessOnTriggerEnterEvent(OnTriggerEnterEvent onTriggerEnterEvent)
		{
			var otherCollisionEventGameObject = onTriggerEnterEvent.other.gameObject;
			var senderCollisionEventGameObject = onTriggerEnterEvent.sender.gameObject;
			
			foreach(var projectileEntity in _projectileGroup)
			{
				if(projectileEntity.hasFreeToReuseTag)
					continue;

				var projectileGameObject = projectileEntity.transformMdl.transform.gameObject;
				
				if(otherCollisionEventGameObject != projectileGameObject && senderCollisionEventGameObject != projectileGameObject)
					continue;
				
				projectileGameObject.SetActive(false);
				projectileEntity.hasFreeToReuseTag = true;
			}
		}
	}
}