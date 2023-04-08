using System;
using System.Collections.Generic;
using Entitas;

namespace Source.Ingame.Health.Sys
{
    public sealed class DecreaseHealthPointsSys : ReactiveSystem<GameplayEntity>
    {
        public DecreaseHealthPointsSys(IContext<GameplayEntity> context) : base(context)
        {
        }

        public DecreaseHealthPointsSys(ICollector<GameplayEntity> collector) : base(collector)
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
                var targetEntity = target as GameplayEntity;
                
                if(targetEntity is not { hasHealthCmp : true })
                    continue;

                float newHealth = targetEntity.healthCmp.healthPoints - damageReq.damageDealt;

                if (newHealth <= 0)
                    targetEntity.hasDeceasedTag = true;
                
                targetEntity.ReplaceHealthCmp(newHealth);
            }
        }
    }
}