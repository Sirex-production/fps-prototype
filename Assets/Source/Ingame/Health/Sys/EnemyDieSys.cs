using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Source.Ingame.Health.Sys
{
    public sealed class EnemyDieSys : ReactiveSystem<GameplayEntity>
    {
        private const float TIME_TO_CLEAR_CORPSE = 5f;
        private const float POWER_OF_DESTRUCTION = 3.5f;
        public EnemyDieSys(IContext<GameplayEntity> context) : base(context)
        {
        }

        public EnemyDieSys(ICollector<GameplayEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
        {
            return context.CreateCollector(GameplayMatcher.DeceasedTag);
        }

        protected override bool Filter(GameplayEntity entity)
        {
            return entity.hasEnemyTag;
        }

        protected override void Execute(List<GameplayEntity> entities)
        {
            foreach (var entity in entities)
            {
                var enemyMdl = entity.aiContextMdl;
                
                enemyMdl.navMeshAgent.updatePosition = false;
                enemyMdl.animator.enabled = false;

                var enemyBody = entity.aiContextMdl.navMeshAgent.gameObject;
                var bones = enemyBody.GetComponentsInChildren<Rigidbody>();
                var player = enemyMdl.player;
                var forceDir = (enemyBody.transform.position - player.position).normalized * POWER_OF_DESTRUCTION;
                
                foreach (var bone in bones)
                {
                    bone.isKinematic = false;
                    bone.useGravity = true;
                    bone.AddForce(forceDir, ForceMode.Impulse);
                }
                var colliders = enemyBody.GetComponentsInChildren<Collider>();

                var playerCollider = entity.aiContextMdl.playerCollider;
                foreach (var collider in colliders)
                {
                    Physics.IgnoreCollision(collider, playerCollider);
                }
                
                Object.Destroy( enemyBody, TIME_TO_CLEAR_CORPSE);
                entity.Destroy();
            }
        }
    }
}