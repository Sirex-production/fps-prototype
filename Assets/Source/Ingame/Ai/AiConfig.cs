using Ingame.Ai.FSM.State;
using Ingame.Bullet;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ingame.Ai
{
    [CreateAssetMenu(fileName = "AiConfig", menuName = "Ai/AiConfig")]
    public sealed class AiConfig : ScriptableObject
    {
        
        [Header("Health")] 
        [SerializeField]
        [Min(0)]
        private float maxHealth;

        [SerializeField] 
        [Min(0)] 
        private float maxShield;
        
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
        
        [SerializeField]
        [Min(0)]
        private float stoppingDistance;
        
        [Header("Detection")]
        [SerializeField]
        [Min(0)] 
        private float detectionRange;
        
        [SerializeField]
        [Range(0,360)] 
        private float detectionAngle;

        [SerializeField] 
        private LayerMask visibilityMask;
        
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

        [SerializeField]
        private bool isRange;

        [FormerlySerializedAs("bullet")]
        [Required] [SerializeField] 
        [ShowIf("IsRange")]
        private BulletBasic bulletBasic;
        public float MaxHealth => maxHealth;

        public float MaxShield => maxShield;

        public StateBase InitState => initState;

        public float DetectionRange => detectionRange;

        public float AttackDamage => attackDamage;

        public float AttackRange => attackRange;

        public float AttackVisionRange => attackVisionRange;

        public float AttackAngle => attackAngle;

        public float ChasingDistance => chasingDistance;

        public float StoppingDistance => stoppingDistance;

        public float DetectionAngle => detectionAngle;

        public LayerMask VisibilityMask => visibilityMask;


        public bool IsRange => isRange;

        public BulletBasic BulletBasic => bulletBasic;
    }
}