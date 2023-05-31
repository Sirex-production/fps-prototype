using System.Collections.Generic;
using Entitas;
using Ingame.Ai.Bullet.Cmp;
using Source.Ingame.Bullet.Service;
using UnityEngine;

namespace Ingame.Bullet.Sys
{
    public sealed class SpawnBulletSys : ReactiveSystem<GameplayEntity>
    {

        private BulletPoolCmp _bulletPool;
        public SpawnBulletSys() : base(Contexts.sharedInstance.gameplay)
        {
            
        }
        public SpawnBulletSys(IContext<GameplayEntity> context) : base(context)
        {
        }

        public SpawnBulletSys(ICollector<GameplayEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.SpawnBulletReq);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasSpawnBulletReq;  
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            _bulletPool ??= Contexts.sharedInstance.gameplay.GetGroup(GameplayMatcher.BulletPoolCmp).GetSingleEntity().bulletPoolCmp;
           
            foreach (var entity in entities)
            {
                var req = entity.spawnBulletReq;
                var bulletEntity = _bulletPool.pools[req.type].Get();
                var bulletBasic = bulletEntity.bulletMdl.bulletBasic;
                
                bulletEntity.ReplaceTransformMdl(req.startingPosition, Quaternion.identity, Vector3.zero);
                bulletEntity.ReplaceForcePowerCmp(req.force);
                bulletEntity.ReplaceDirectionCmp(req.direction);
                
                bulletBasic.InitDamage(req.damage);
                bulletBasic.AttachedRigidbody.velocity = Vector3.zero;
                bulletBasic.AttachedRigidbody.angularVelocity = Vector3.zero;
                bulletBasic.transform.position = req.startingPosition.position;
                bulletBasic.AttachedRigidbody.AddForce(req.force*req.direction, ForceMode.Impulse);

                if (bulletEntity.hasFreeToReuseTag)
                    bulletEntity.hasFreeToReuseTag = false;
          
                entity.Destroy();   
            }
        }
    }
}