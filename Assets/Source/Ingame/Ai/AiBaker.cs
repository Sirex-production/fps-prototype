using Ingame.Ai.Cmp;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Ingame.Ai
{
    public sealed class AiBaker : MonoBehaviour
    {
        [Required]
        [SerializeField] 
        private NavMeshAgent navMeshAgent;

        [Required]
        [SerializeField] 
        private AiConfig aiConfig;
        
        [Inject]
        private void Construct()
        {
            var entity = Contexts.sharedInstance.gameplay.CreateEntity();
            entity.AddAiContextMdl(navMeshAgent, aiConfig, null, aiConfig.InitState,true,0);
        }
    }
}