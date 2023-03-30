

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
        private AiConfig aiConfig;
        
        [Required]
        [SerializeField] 
        private Animator animator;
        
        [Inject]
        private void Construct()
        {
            var entity = Contexts.sharedInstance.gameplay.CreateEntity();
            entity.AddAiContextMdl(navMeshAgent, aiConfig, null,  animator , new AiStateWrapper());
        }
    }
}