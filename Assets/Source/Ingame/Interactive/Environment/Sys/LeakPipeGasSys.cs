using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Ingame.Interactive.Environment.Sys
{
    public sealed class LeakPipeGasSys : ReactiveSystem<GameplayEntity>
    {
    

        public LeakPipeGasSys(IContext<GameplayEntity> context) : base(context)
        {
        }

        public LeakPipeGasSys(ICollector<GameplayEntity> collector) : base(collector)
        {
        }
        
        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.PerformInteractionTag);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasGasPipeTag && entity.hasInteractiveObjectTag && entity.hasParticleEffectMdl;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            foreach (var entity in entities)
            {
                var particleEffect = entity.particleEffectMdl;
                particleEffect.effect.Play();
            }
        }

    }
}