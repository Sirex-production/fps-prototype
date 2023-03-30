using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    public abstract class RepositionAction : ActionBase
    {
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            if (aiContextMdl.navMeshAgent.pathPending)
                return ActionStatus.Running; 
            
            aiContextMdl.navMeshAgent.stoppingDistance = aiContextMdl.aiConfig.ChasingDistance;
            
            if (!(aiContextMdl.navMeshAgent.remainingDistance <= aiContextMdl.navMeshAgent.stoppingDistance))
                return ActionStatus.Running;
            
            aiContextMdl.navMeshAgent.velocity = Vector3.zero;
            return ActionStatus.Done;

        }
    }
}