using System.Collections.Generic;
using Entitas;

namespace Source.Ingame.AiSupport.Sys
{
    public sealed class AiTeleportSys : ReactiveSystem<GameplayEntity>
    {
        private readonly IGroup<GameplayEntity> _teleportationPads;
        public AiTeleportSys() : base(Contexts.sharedInstance.gameplay)
        {
        }
        
        public AiTeleportSys(IContext<GameplayEntity> context) : base(context)
        {
        }

        public AiTeleportSys(ICollector<GameplayEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.AiTeleportRequest);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasEnemyTag && entity.hasAiContextMdl;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            foreach (var entity in entities)
            {
                

                entity.hasAiTeleportRequest = false;
            }
        }
    }
}