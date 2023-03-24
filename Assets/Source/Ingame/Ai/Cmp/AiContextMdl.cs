using Entitas;
using Ingame.Ai.FSM.State;
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
            
        //World
        public Transform player;
        //FSM
        public StateBase curentState;
        public bool wasStateChanged;
        public int actionIndex;

    }
}