using System;
using System.Collections.Generic;
using EcsSupport.UnityIntegration;
using Entitas;
using Ingame.Bullet;
using UnityEngine;


namespace Source.Ingame.Bullet.Service
{
    public sealed class BulletService
    {
        private static BulletService _bulletService;

        public HashSet<GameplayEntity> FreeEntities = new();
        public static BulletService Instance => _bulletService ??= new BulletService();

        public void SpawnBullet(Type t, Transform startingPosition, Vector3 direction, float force, float damage)
        {
            Contexts.sharedInstance.gameplay.CreateEntity().AddSpawnBulletReq(t,startingPosition, direction ,force,damage);
        }

        public void ReleaseBullet(BulletBasic bulletBasic)
        {
            var entityReference = bulletBasic.gameObject.GetComponent<GameplayEntityReference>();
            Contexts.sharedInstance.gameplay.CreateEntity().AddReleaseBulletReq(entityReference.attachedEntity);
        }
    }
}