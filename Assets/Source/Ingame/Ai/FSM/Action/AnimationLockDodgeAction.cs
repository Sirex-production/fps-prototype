using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [CreateAssetMenu(fileName = "AnimationLockDodgeAction", menuName = "Ai/Action/AnimationLockDodgeAction")]
    public sealed class AnimationLockDodgeAction : ActionBase
    {
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {        
            aiContextMdl.navMeshAgent.updateRotation = false;
            aiContextMdl.navMeshAgent.updatePosition = false;

            aiContextMdl.animator.SetBool("IsDodging", true);
            
            return ActionStatus.Done;
        }
    }
}