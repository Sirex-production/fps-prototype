using EcsSupport.UnityIntegration;
using EcsSupport.UnityIntegration.Physics;
using Entitas;
using Source.Ingame.Health;
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

				var damage = 1f;
				if (projectileEntity.hasArrowCmp)
					damage = projectileEntity.arrowCmp.damage;
				
				
				if (otherCollisionEventGameObject.TryGetComponent<DamageMultiplier>(out var damageMultiplier))
				{
					damageMultiplier.ApplyDamage(damage);
					continue;
				}
				
				if (!otherCollisionEventGameObject.transform.root.TryGetComponent<GameplayEntityReference>(out var entityReference))
					continue;
				
				if(entityReference.attachedEntity.hasAiHealthCmp)
					Contexts.sharedInstance.gameplay.CreateEntity().AddTakeDamageReq(damage,entityReference.attachedEntity);
			}
		}
	}
}