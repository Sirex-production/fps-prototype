using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [CreateAssetMenu(fileName = "AnimationIsDoneAction", menuName = "Ai/Action/AnimationIsDoneAction")]
    public sealed class AnimationIsDoneAction : ActionBase
    {
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            var result = aiContextMdl.animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
            return result ? ActionStatus.Running : ActionStatus.Done;
        }
    }
}