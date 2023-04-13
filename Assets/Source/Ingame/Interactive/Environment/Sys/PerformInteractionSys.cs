using System.Collections.Generic;
using Entitas;

namespace Ingame.Interactive.Environment.Sys
{
    public sealed class PerformInteractionSys : ReactiveSystem<GameplayEntity>
    {
        public PerformInteractionSys(IContext<GameplayEntity> context) : base(context)
        {
        }

        public PerformInteractionSys(ICollector<GameplayEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.PerformInteractionTag);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            
        }
    }
}