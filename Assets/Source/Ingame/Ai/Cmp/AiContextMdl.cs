using Entitas;
using Ingame.Ai.FSM.State;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

namespace Ingame.Ai.Cmp
{
    [Gameplay]
    public sealed class AiContextMdl : IComponent
    {
        //Config 
        public NavMeshAgent navMeshAgent;
        public AiConfig aiConfig;
        public Transform player;
        public Animator animator;
        //FSM
        public AiStateWrapper aiStateWrapper;
        
    }
    
    
}