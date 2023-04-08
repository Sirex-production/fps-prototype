using System;
using System.Collections.Generic;
using Ingame.Ai.Cmp;
using NaughtyAttributes;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{ [Serializable]
    [CreateAssetMenu(fileName = "AnimationAwaitBoolAction", menuName = "Ai/Action/AnimationAwaitBoolAction")]
    public class AnimationAwaitBoolAction : AnimationAction
    {
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            var resp = aiContextMdl.animator.GetBool(VariableAnimationHash);
            return resp ? ActionStatus.Running : ActionStatus.Done;
        }
    }
}