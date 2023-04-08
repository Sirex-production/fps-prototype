

using System;
using Entitas.Unity;
using Ingame.Ai.Cmp;
using Ingame.Ai.FSM;
using NaughtyAttributes;
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

        [Inject(Id = "Player")]
        private Transform _playerTransform;
        
        public NavMeshAgent NavMeshAgent => navMeshAgent;

        public AiConfig AIConfig => aiConfig;

        public Animator Animator => animator;

        public Transform Weapon => weapon;

        public Transform PlayerTransform => _playerTransform;

        [Inject]
        private void Construct()
        {
            var entity = Contexts.sharedInstance.gameplay.CreateEntity();
            
            entity.AddAiContextMdl(navMeshAgent, aiConfig, null, animator , new AiStateWrapper());
            entity.AddHealthCmp(aiConfig.MaxHealth);
            entity.hasEnemyTag = true;

            gameObject.Link(entity);
        }

        private void OnDestroy()
        {
            gameObject.Unlink();
        }
    }
}