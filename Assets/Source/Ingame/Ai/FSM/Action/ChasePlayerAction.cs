using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [CreateAssetMenu(fileName = "ChaseAction", menuName = "Ai/Action/Chase")]
    public sealed class ChasePlayerAction : RepositionAction
    {
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            aiContextMdl.navMeshAgent.destination = aiContextMdl.player.position;
            return base.Run(aiContextMdl);
        }
    }
}