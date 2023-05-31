using System;
using System.Collections.Generic;
using EcsSupport.UnityIntegration;
using Entitas;
using Source.Ingame.Health;
using UnityEngine;

namespace Ingame.Gunplay.MeleeAttack
{
	public sealed class PerformMeleeAttackSystem : ReactiveSystem<GameplayEntity>
	{
		private readonly Collider[] _cashedColliders = new Collider[32];
		private readonly List<GameplayEntity> _enemyEntities = new();

		public PerformMeleeAttackSystem(IContext<GameplayEntity> context) : base(context)
		{
		}
		
		protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
		{
			return context.CreateCollector(GameplayMatcher.PerformMeleeAttackReq);
		}

		protected override bool Filter(GameplayEntity entity)
		{
			return true;
		}

		protected override void Execute(List<GameplayEntity> entities)
		{
			var meleeAttackOriginEntity = Contexts.sharedInstance.gameplay.meleeAttackOriginTagEntity;
			
			if(!meleeAttackOriginEntity.hasTransformMdl)
				return;

			var meleeTackOriginTransform = meleeAttackOriginEntity.transformMdl.transform;
			
			foreach(var entity in entities)
			{
				var performMeleeAttackReq = entity.performMeleeAttackReq;
				var spherecastCenter = meleeTackOriginTransform.position + meleeTackOriginTransform.forward * performMeleeAttackReq.range;

				int collidersHitCount = Physics.OverlapSphereNonAlloc(spherecastCenter, performMeleeAttackReq.range, _cashedColliders);

				for(int i = 0; i < collidersHitCount; i++)
					ApplyDamage(_cashedColliders[i], performMeleeAttackReq.damage);
				
				_enemyEntities.Clear();
			}
		}

		private void ApplyDamage(Collider collider, float damage)
		{
			if (collider.TryGetComponent(out DamageMultiplier damageMultiplier))
			{
				if(_enemyEntities.Contains(damageMultiplier.CashedParentBody))
					return;
				
				_enemyEntities.Add(damageMultiplier.CashedParentBody);
				damageMultiplier.ApplyDamage(Math.Max(0f, damage));
				return;
			}
			
			if(!collider.transform.root.TryGetComponent(out GameplayEntityReference entityReference))
				return;
	
			if(entityReference.attachedEntity.hasPlayerCmp)
				return;
	
			if(!entityReference.attachedEntity.hasAiHealthCmp)
				return;
		
			if(_enemyEntities.Contains(entityReference.attachedEntity))
			   return;
			
			_enemyEntities.Add(entityReference.attachedEntity);
			Contexts.sharedInstance.gameplay.CreateEntity().AddTakeDamageReq(Math.Max(0f, damage),entityReference.attachedEntity);
		}
	}
}