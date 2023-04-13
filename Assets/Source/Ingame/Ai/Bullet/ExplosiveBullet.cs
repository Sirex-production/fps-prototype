using System.Collections.Generic;
using Entitas.Unity;
using Ingame.Player;
using UnityEngine;

namespace Ingame.Ai.Bullet
{
    public sealed class ExplosiveBullet : Bullet
    {

        public bool shouldSpawn = true;
        private void Start()
        {
            Destroy(gameObject, lifeSpan);
        }
        
        
        private void CreateExplosiveFragments()
        {
            if(!shouldSpawn)
                return;
            var x = Instantiate(gameObject);
            x.GetComponent<ExplosiveBullet>().shouldSpawn = false;
            x.GetComponent<Rigidbody>().AddForce(Vector3.up*3);
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            CreateExplosiveFragments();
            
            if (!collision.transform.root.TryGetComponent<PlayerBaker>(out var player))
            {
                Destroy(gameObject);
                return;
            }
            
            var takeDamageReq = Contexts.sharedInstance.gameplay.CreateEntity();
            takeDamageReq.AddTakeDamageRequest(damage, player.gameObject.GetEntityLink().entity as GameplayEntity);
            Destroy(gameObject);
        } 
    }
}