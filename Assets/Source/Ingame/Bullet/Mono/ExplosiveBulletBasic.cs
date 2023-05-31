using EcsSupport.UnityIntegration;
using Entitas.Unity;
using Ingame.Player;
using NaughtyAttributes;
using Source.Ingame.Bullet.Service;
using UnityEngine;

namespace Ingame.Bullet
{
    public sealed class ExplosiveBulletBasic : BulletBasic
    {
        [Required]
        [SerializeField]
        private ExplosiveBulletFragBasic explosiveBulletFragBasic;
 
        private void Start()
        {
            Destroy(gameObject, lifeSpan);
        }
        
        
        private void CreateExplosiveFragments()
        {
            for (int i = 0; i < 5; i++)
            {
                var dir = (Vector3.up + Vector3.left *Random.Range(-0.4f, 0.4f)).normalized;
                BulletService.Instance.SpawnBullet(explosiveBulletFragBasic.GetType(), transform, dir, 11,5);
            }
            
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.root.TryGetComponent<GameplayEntityReference>(out var entityReference)
                && !entityReference.attachedEntity.hasApplyDamageCmp)
            {
                entityReference.attachedEntity.AddApplyDamageCmp(damage);
            }
            CreateExplosiveFragments();
            BulletService.Instance.ReleaseBullet(this);
           
        } 
    }
}