using Entitas;
using Ingame.Ai.FSM.State;
using UnityEngine.AI;

namespace Ingame.Ai.Cmp
{
    [Gameplay]
    public sealed class AiContextMdl : IComponent
    {
         
        public NavMeshAgent navMeshAgent;
        public AiConfig aiConfig;

        //FSM
        public StateBase curentState;
        public bool wasStateChanged;
        public int actionIndex;

    }
}