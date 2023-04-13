using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.State
{
    [CreateAssetMenu(fileName = "ChaseStateConfig", menuName = "Ai/State/Chase")]
    public sealed class ChaseState : StateBase
    {
        protected override void OnEnter(AiContextMdl aiContextMdl)
        {
            aiContextMdl.navMeshAgent.isStopped = false;
        }

        protected override void OnExit(AiContextMdl aiContextMdl)
        {
            aiContextMdl.navMeshAgent.isStopped = true;
        }
    }
}