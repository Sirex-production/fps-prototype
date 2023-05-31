using System.Collections.Generic;
using Entitas;
using Ingame.Ai.Bullet.Cmp;
using Source.Ingame.Bullet.Service;
using UnityEngine;

namespace Ingame.Bullet.Sys
{
    public sealed class DisposeBulletSys : ReactiveSystem<GameplayEntity>
    { 
        private BulletPoolCmp _bulletPool;
        public DisposeBulletSys() : base(Contexts.sharedInstance.gameplay)
        {
            
        }
        public DisposeBulletSys(IContext<GameplayEntity> context) : base(context)
        {
        }

        public DisposeBulletSys(ICollector<GameplayEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.ReleaseBulletReq);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasReleaseBulletReq; 
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            _bulletPool ??= Contexts.sharedInstance.gameplay.GetGroup(GameplayMatcher.BulletPoolCmp).GetSingleEntity().bulletPoolCmp;
           
            foreach (var entity in entities)
            {
                var req = entity.releaseBulletReq;
                var bulletEntity = req.gameplayEntity;
                var bulletType = bulletEntity.bulletMdl.bulletBasic.GetType();
                
                if (!bulletEntity.hasFreeToReuseTag)
                {
                    bulletEntity.hasFreeToReuseTag = true;
                    _bulletPool.pools[bulletType].Release(bulletEntity);
                }
                
                entity.Destroy();   
            } 
        }
    }
}