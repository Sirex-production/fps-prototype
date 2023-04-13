using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ingame.Ai.Bullet
{
    public abstract class Bullet : MonoBehaviour
    {
        [Required] [SerializeField] protected Rigidbody attachedRigidbody;
        [SerializeField] 
        protected float lifeSpan;
        public Rigidbody AttachedRigidbody => attachedRigidbody;

        protected float damage;

        public void Init(AiConfig config)
        {
            damage = config.AttackDamage;
        }
    }
}