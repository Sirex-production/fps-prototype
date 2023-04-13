using Entitas;
using UnityEngine;

namespace Source.Ingame.Health
{
    public sealed class DamageMultiplier : MonoBehaviour
    {
        [SerializeField] [Range(0, 10)] private float damageRate;

        private GameplayEntity _cashedParentBody;

        public GameplayEntity CashedParentBody
        {
            set
            {
                if (_cashedParentBody != null)
                    return;

                _cashedParentBody = value;
            }
        }
        
        public void ApplyDamage(float damage)
        {
            var entity = Contexts.sharedInstance.gameplay.CreateEntity();
            entity.AddTakeDamageRequest(damage*damageRate, _cashedParentBody);
        }
    }
}