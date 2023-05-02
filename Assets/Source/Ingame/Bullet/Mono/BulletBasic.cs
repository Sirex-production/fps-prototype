using Ingame.Ai;
using NaughtyAttributes;
using UnityEngine;


namespace Ingame.Bullet
{
    public abstract class BulletBasic : MonoBehaviour
    {
        [Required] [SerializeField] protected Rigidbody attachedRigidbody;
        [SerializeField] 
        protected float lifeSpan;
        public Rigidbody AttachedRigidbody => attachedRigidbody;

        protected float damage;

        public void InitDamage(float damage)
        {
            this.damage = damage;
        }
    }
}