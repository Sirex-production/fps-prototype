using NaughtyAttributes;
using UnityEngine;

namespace Ingame.Ai.Bullet
{
    public abstract class Bullet : MonoBehaviour
    {
        [Required] [SerializeField] protected Rigidbody rigidbody;
        [SerializeField] 
        protected float lifeSpan;
        public Rigidbody Rigidbody => rigidbody;

        protected float damage;

        public void Init(AiConfig config)
        {
            damage = config.AttackDamage;
        }
    }
}