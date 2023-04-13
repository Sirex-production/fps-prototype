using System;
using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [Serializable]
    [CreateAssetMenu(fileName = "AnimationLockBoolAction", menuName = "Ai/Action/AnimationLockBoolAction")]
    public class AnimationLockBoolAction : AnimationAction
    {
        [SerializeField] private bool boolValue = true;
        
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            aiContextMdl.animator.SetBool(VariableAnimationHash, boolValue);
            return ActionStatus.Done;
        }
    }
}