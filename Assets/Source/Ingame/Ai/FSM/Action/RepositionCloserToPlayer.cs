using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [CreateAssetMenu(fileName = "RepositionCloserToPlayerAction", menuName = "Ai/Action/RepositionCloserToPlayer")]
    public sealed class RepositionCloserToPlayer : RepositionAction
    {
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            aiContextMdl.navMeshAgent.destination = aiContextMdl.player.position;
            return base.Run(aiContextMdl);
        }
    }
}