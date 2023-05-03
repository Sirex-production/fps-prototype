

using System;
using EcsSupport.UnityIntegration;
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
    [RequireComponent( typeof(GameplayEntityReference))]
    public sealed class AiBaker : MonoBehaviour
    {
        [Required]
        [SerializeField] 
        private GameplayEntityReference gameplayEntityReference;
        
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

        [SerializeField] 
        [Required] 
        private Transform modelWrapper;
        
        [SerializeField] 
        private bool isMovementByAnimation = false;
        
        [SerializeField] 
        private bool isFlying = false;
        
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
            
            entity.AddAiContextMdl(navMeshAgent, aiConfig, null,null, animator , weapon,new AiStateWrapper(),new AiAnimationWrapper());
            entity.AddAiHealthCmp(aiConfig.MaxHealth);
            entity.AddShieldCmp(aiConfig.MaxShield);
            entity.AddAiModelWrapperContainerMdl(modelWrapper);
            entity.hasEnemyTag = true;
            entity.AddClearLinkOnDestroyMdl(gameObject);

            if (isMovementByAnimation)
                entity.hasMovementByAnimationsTag = true;
            
            if(isFlying)
                entity.AddFlyingAiCmp(Vector3.zero);
            
            _entity = entity;

            gameplayEntityReference.attachedEntity = entity;
            InjectEntity();

            var rbs = GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }
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