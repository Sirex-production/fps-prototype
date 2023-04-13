using System;
using Entitas.Unity;
using Ingame.Player;
using UnityEngine;

namespace Ingame.Ai.Bullet
{
    public sealed class StandardBullet : Bullet
    {
        private void Start()
        {
            Destroy(gameObject, lifeSpan);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(!collision.transform.root.TryGetComponent<PlayerBaker>(out var player))
                return;

            var takeDamageReq = Contexts.sharedInstance.gameplay.CreateEntity();
            takeDamageReq.AddTakeDamageRequest(damage, player.gameObject.GetEntityLink().entity as GameplayEntity);
        }
    }
}