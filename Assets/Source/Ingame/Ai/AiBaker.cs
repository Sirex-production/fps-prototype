

using System;
using Entitas;
using Entitas.Unity;
using Ingame.Ai.Cmp;
using Ingame.Ai.FSM;
using NaughtyAttributes;
using Source.Ingame.Health;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Ingame.Ai
{
    [RequireComponent(typeof(AiEventHandler))]
    public sealed class AiBaker : MonoBehaviour
    {
        [Required]
        [SerializeField] 
        private NavMeshAgent navMeshAgent;

        [Required]
        [SerializeField] 
        [Expandable]
        private AiConfig aiConfig;
        
        [Required]
        [SerializeField] 
        private Animator animator;
        
        [SerializeField] 
        [Required] 
        private Transform weapon;
        
        
        private GameplayEntity _entity;
        
        public NavMeshAgent NavMeshAgent => navMeshAgent;

        public AiConfig AIConfig => aiConfig;

        public Animator Animator => animator;

        public Transform Weapon => weapon;

        public GameplayEntity Entity => _entity;

        [Inject]
        private void Construct()
        {
            var entity = Contexts.sharedInstance.gameplay.CreateEntity();
            
            entity.AddAiContextMdl(navMeshAgent, aiConfig, null,null, animator , weapon,new AiStateWrapper());
            entity.AddAiHealthCmp(aiConfig.MaxHealth);
            entity.AddShieldCmp(aiConfig.MaxShield);
            entity.hasEnemyTag = true;
            
            _entity = entity;
            
            gameObject.Link(entity);
            InjectEntity(); 
        }

        private void OnDestroy()
        {
            gameObject.Unlink();
        }

        private void InjectEntity()
        {
            var damageMultipliers = transform.GetComponentsInChildren<DamageMultiplier>();
            foreach (var damageMultiplier in damageMultipliers)
            {
                damageMultiplier.CashedParentBody = _entity;
            }
        }
    }
}