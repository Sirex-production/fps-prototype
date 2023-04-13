using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Entitas;
using UnityEngine;

namespace Source.Ingame.Health.Sys
{
    public sealed class DecreaseAiHealthPointsSys : ReactiveSystem<GameplayEntity> 
    {
        public DecreaseAiHealthPointsSys(IContext<GameplayEntity> context) : base(context)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.TakeDamageRequest);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasTakeDamageRequest;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            foreach (var entity in entities)
            {
                var damageReq = entity.takeDamageRequest;
                var target = damageReq.target;
                
                if (target is not { hasHealthCmp : true })
                {
                    entity.Destroy();
                    continue;
                }
                
                float damageToDeal = damageReq.damageDealt;
                
                if (target.hasShieldCmp)
                    ApplyDamageToShield(target, ref damageToDeal);

                ApplyDamageToHealth(target, damageToDeal);
                entity.Destroy();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ApplyDamageToShield(GameplayEntity target, ref float damageToDeal)
        {
            float shieldAmount = target.shieldCmp.shieldPoints;
                    
            if(shieldAmount <= 0)
                return;
            
            target.ReplaceShieldCmp(Mathf.Clamp(shieldAmount, 0, shieldAmount - damageToDeal));
            damageToDeal = Mathf.Clamp(damageToDeal, 0, damageToDeal - shieldAmount);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ApplyDamageToHealth(GameplayEntity target, float damageToDeal)
        {
            float newHealth = target.aiHealthCmp.healthPoints - damageToDeal;

            if (newHealth <= 0)
                target.hasDeceasedTag = true;
                
            target.ReplaceAiHealthCmp(newHealth);
        }
    }
}