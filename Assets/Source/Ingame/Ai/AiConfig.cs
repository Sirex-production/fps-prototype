using Ingame.Ai.FSM.State;
using NaughtyAttributes;
using UnityEngine;

namespace Ingame.Ai
{
    [CreateAssetMenu(fileName = "AiConfig", menuName = "Ai/AiConfig")]
    public sealed class AiConfig : ScriptableObject
    {
        [Header("Health")] 
        [SerializeField]
        [Min(0)]
        private float maxHealth;

        [Header("FSM")] 
        [Required]
        [SerializeField]
        private StateBase initState;
        
        [Header("Movement")]
        [SerializeField]
        [Min(0)]
        private float chasingDistance;
        
        [SerializeField]
        [Min(0)]
        private float movementSpeed;
        
        [Header("Detection")]
        [SerializeField]
        [Min(0)] 
        private float detectionRange;

        [Header("Attack")]
        [SerializeField]
        [Min(0)]
        private float attackDamage;
        
        [SerializeField]
        [Min(0)]
        private float attackRange;
        
        [SerializeField]
        [Min(0)]
        private float attackVisionRange;

        [SerializeField]
        [Range(0,360)]
        private float attackAngle;
        
        public float MaxHealth => maxHealth;

        public StateBase InitState => initState;

        public float DetectionRange => detectionRange;

        public float AttackDamage => attackDamage;

        public float AttackRange => attackRange;

        public float AttackVisionRange => attackVisionRange;

        public float AttackAngle => attackAngle;

        public float ChasingDistance => chasingDistance;
    }
}