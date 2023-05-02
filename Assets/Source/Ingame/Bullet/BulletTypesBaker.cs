using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using Ingame.Bullet;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Source.Ingame.Bullet
{
    public sealed class BulletTypesBaker : MonoBehaviour
    {
        [SerializeReference] 
        private List<BulletBasic> bulletBasics;
        
        private void Awake()
        {
            var entity = Contexts.sharedInstance.gameplay.CreateEntity();
         
            entity.AddBulletTypesMdl(bulletBasics.ToDictionary(e=> e.GetType(),e=>e));
            entity.AddBulletPoolCmp(null);
        }
    }
}