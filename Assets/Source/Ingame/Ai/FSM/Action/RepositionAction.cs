using Ingame.Ai.Cmp;
using UnityEngine;
using UnityEngine.AI;

namespace Ingame.Ai.FSM.Action
{
    public abstract class RepositionAction : ActionBase
    {
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            
            if (aiContextMdl.navMeshAgent.pathPending)
            {
                aiContextMdl.navMeshAgent.isStopped = false;
                return ActionStatus.Running;
            }

            aiContextMdl.navMeshAgent.stoppingDistance = aiContextMdl.aiConfig.StoppingDistance;
            if (!(aiContextMdl.navMeshAgent.remainingDistance <= aiContextMdl.navMeshAgent.stoppingDistance))
            {
                aiContextMdl.navMeshAgent.isStopped = false;
                return ActionStatus.Running;
            }

            if (aiContextMdl.navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid)
            {
                aiContextMdl.navMeshAgent.isStopped = true;
                return ActionStatus.Done;
            }
            
            aiContextMdl.navMeshAgent.isStopped = true;
            return ActionStatus.Done;

        }
    }
}