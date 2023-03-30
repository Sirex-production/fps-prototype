using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [CreateAssetMenu(fileName = "NavMeshTransformAction", menuName = "Ai/Action/NavMeshTransformAction")]
    public sealed class NavMeshTransformAction : ActionBase
    {
        [SerializeField] private bool isEnable;
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            aiContextMdl.navMeshAgent.updateRotation = isEnable;
            aiContextMdl.navMeshAgent.updatePosition = isEnable;

            return ActionStatus.Done;
        }
    }
}