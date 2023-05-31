using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Ingame.Effects
{
	public sealed class ApplyDamageSystem : ReactiveSystem<GameplayEntity>
	{
		public ApplyDamageSystem(IContext<GameplayEntity> context) : base(context)
		{
		}

		protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
		{
			return context.CreateCollector(GameplayMatcher.AllOf(GameplayMatcher.HealthCmp, GameplayMatcher.ApplyDamageCmp));
		}

		protected override bool Filter(GameplayEntity entity)
		{
			return true;
		}

		protected override void Execute(List<GameplayEntity> entities)
		{
			foreach(var entity in entities)
			{
				var healthCmp = entity.healthCmp;
				var applyDamageCmp = entity.applyDamageCmp;

				applyDamageCmp.amountOfDamage = Mathf.Max(0f, applyDamageCmp.amountOfDamage);
				float damageShouldBetaken = applyDamageCmp.amountOfDamage;
				
				if(entity.hasArmorCmp)
				{
					var armorCmp = entity.armorCmp;
					armorCmp.currentArmor -= applyDamageCmp.amountOfDamage * armorCmp.percentageOfArmorTaken;

					damageShouldBetaken = armorCmp.currentArmor <= 0f ? 
						applyDamageCmp.amountOfDamage :
						applyDamageCmp.amountOfDamage - applyDamageCmp.amountOfDamage * armorCmp.percentageOfArmorTaken;
				}

				healthCmp.currentHealth -= damageShouldBetaken;

				if(healthCmp.currentHealth <= 0f)
					entity.hasIsDeadTag = true;
				
				entity.RemoveApplyDamageCmp();
			}
		}
	}
}