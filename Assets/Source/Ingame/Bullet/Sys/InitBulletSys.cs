using System;
using System.Collections.Generic;
using EcsSupport.UnityIntegration;
using Entitas;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Ingame.Bullet.Sys
{
    public sealed class InitBulletSys : IInitializeSystem
    {
        public void Initialize()
        {
            var entity = Contexts.sharedInstance.gameplay.GetGroup(GameplayMatcher.AllOf(
                GameplayMatcher.BulletTypesMdl,
                GameplayMatcher.BulletPoolCmp
            )).GetSingleEntity();

            entity.bulletPoolCmp.pools = ConvertToBulletPoolField(entity.bulletTypesMdl.bulletsTypes);
        }
        
        private Dictionary<Type, IObjectPool<GameplayEntity>> ConvertToBulletPoolField(Dictionary<Type, BulletBasic> bullets)
        {
            Dictionary<Type, IObjectPool<GameplayEntity>> dictionary = new();
            
            foreach (var (bulletType,bullet) in bullets)
            {
                if (dictionary.ContainsKey(bulletType))
                {
                    Debug.LogWarning($"Types of bullets are repeated at least once!!!!");
                    continue;
                }
                
                dictionary.Add(bulletType, new ObjectPool<GameplayEntity>(
                    ()=> OnBulletCreate(bullet),
                    OnBulletGet,
                    OnBulletRelease,
                    OnBulletDestroy)
                );
            }

            return dictionary;
        }

        private GameplayEntity OnBulletCreate(BulletBasic bulletBasic)
        {
            var bullet = Object.Instantiate(bulletBasic.gameObject);
            var entity = Contexts.sharedInstance.gameplay.CreateEntity();
            bullet.gameObject.GetComponent<GameplayEntityReference>().attachedEntity = entity;
            
            entity.AddBulletMdl(bullet.GetComponent<BulletBasic>());
            entity.AddTransformMdl(null,Quaternion.identity, Vector3.zero);
            entity.AddForcePowerCmp(0f);
            entity.AddDirectionCmp(Vector3.zero);
            
            return entity;
        }
        private void OnBulletGet(GameplayEntity obj)
        {
            var bulletMdl = obj.bulletMdl;
            bulletMdl.bulletBasic.gameObject.SetActive(true);
        }
        
        private void OnBulletDestroy(GameplayEntity obj)
        {
           
        }

        private void OnBulletRelease(GameplayEntity obj)
        {
            var bulletMdl = obj.bulletMdl;
            bulletMdl.bulletBasic.gameObject.SetActive(false);
        }

      
    }
}