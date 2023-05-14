using System;
using System.Collections.Generic;
using EcsSupport.UnityIntegration;
using Entitas;
using UnityEngine;

namespace Ingame.Gunplay.MeleeAttack
{
	public sealed class PerformMeleeAttackSystem : ReactiveSystem<GameplayEntity>
	{
		private readonly Collider[] _cashedColliders = new Collider[32];
		
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
			}
		}

		private void ApplyDamage(Collider collider, float damage)
		{
			if(!collider.TryGetComponent(out GameplayEntityReference entityReference))
				return;
			
			if(!entityReference.attachedEntity.hasHealthCmp)
				return;
			
			if(entityReference.attachedEntity.hasPlayerCmp)
				return;
			
			entityReference.attachedEntity.AddApplyDamageCmp(Math.Max(0f, damage));
		}
	}
}