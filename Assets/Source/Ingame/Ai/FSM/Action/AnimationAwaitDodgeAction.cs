using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [CreateAssetMenu(fileName = "AnimationAwaitDodgeAction", menuName = "Ai/Action/AnimationAwaitDodgeAction")]
    public sealed class AnimationAwaitDodgeAction : ActionBase
    {
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
             var resp = aiContextMdl.animator.GetBool("IsDodging");
             
             if (resp)
                 return ActionStatus.Running;
                     
             aiContextMdl.navMeshAgent.updateRotation = true;
             aiContextMdl.navMeshAgent.updatePosition = true;
            return  ActionStatus.Done;
        }
    }
}