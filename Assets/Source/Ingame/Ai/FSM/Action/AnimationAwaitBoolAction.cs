using System.Collections.Generic;
using Ingame.Ai.Cmp;
using NaughtyAttributes;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [CreateAssetMenu(fileName = "AnimationAwaitBoolAction", menuName = "Ai/Action/AnimationAwaitBoolAction")]
    public class AnimationAwaitBoolAction : AnimationAction
    {
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            var resp = aiContextMdl.animator.GetBool(variableAnimationName);
            return resp ? ActionStatus.Running : ActionStatus.Done;
        }
    }
}