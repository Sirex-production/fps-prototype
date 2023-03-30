using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.State
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "Ai/State/IdleState")]
    public sealed class IdleState : StateBase
    {
        protected override void OnEnter(AiContextMdl aiContextMdl)
        {
            aiContextMdl.navMeshAgent.isStopped = true;
        }

        protected override void OnExit(AiContextMdl aiContextMdl)
        {
            
        }
    }
}