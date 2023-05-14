using System;
using System.Collections;
using EcsSupport.UnityIntegration;
using Entitas.Unity;
using Ingame.Player;
using Source.Ingame.Bullet.Service;
using UnityEngine;

namespace Ingame.Bullet
{
    public sealed class StandardBulletBasic : BulletBasic
    {
        private Coroutine _coroutine;
        private void OnEnable()
        {
            _coroutine = StartCoroutine(DestroyObject());
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.root.TryGetComponent<GameplayEntityReference>(out var entityReference)
                && !entityReference.attachedEntity.hasApplyDamageCmp)
            {
                entityReference.attachedEntity.AddApplyDamageCmp(damage);
                BulletService.Instance.ReleaseBullet(this);
            }

        }

        private IEnumerator DestroyObject()
        {
            yield return new WaitForSeconds(lifeSpan);
            BulletService.Instance.ReleaseBullet(this);
        }
    }
}