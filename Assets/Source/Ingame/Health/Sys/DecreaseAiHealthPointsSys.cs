using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Entitas;
using UnityEngine;

namespace Source.Ingame.Health.Sys
{
    public sealed class DecreaseAiHealthPointsSys : ReactiveSystem<GameplayEntity> 
    {
        public DecreaseAiHealthPointsSys() : base(Contexts.sharedInstance.gameplay)
        {
            
        }
        public DecreaseAiHealthPointsSys(IContext<GameplayEntity> context) : base(context)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(
                GameplayMatcher.AllOf(
                    GameplayMatcher.TakeDamageReq
                )
                );
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasTakeDamageReq;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            foreach (var entity in entities)
            {
          
                var damageReq = entity.takeDamageReq;
                var target = damageReq.target;
          
                if (target is not { hasAiHealthCmp : true })
                {
                    entity.Destroy();
                    continue;
                }
                
                float damageToDeal = damageReq.damageDealt;
                
                if (target.hasShieldCmp)
                    ApplyDamageToShield(ref target, ref damageToDeal);

                ApplyDamageToHealth(ref target, damageToDeal);
                entity.Destroy();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ApplyDamageToShield(ref GameplayEntity target, ref float damageToDeal)
        {
            float shieldAmount = target.shieldCmp.shieldPoints;
                    
            if(shieldAmount <= 0)
                return;
          
            target.ReplaceShieldCmp(Mathf.Max( 0, shieldAmount - damageToDeal));
            damageToDeal = Mathf.Max(0, damageToDeal - shieldAmount);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ApplyDamageToHealth(ref GameplayEntity target, float damageToDeal)
        {
            float newHealth = target.aiHealthCmp.healthPoints - damageToDeal;

            if (newHealth <= 0)
                target.hasDeceasedTag = true;
                
            target.ReplaceAiHealthCmp(newHealth);
        }
    }
}