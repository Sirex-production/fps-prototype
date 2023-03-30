using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [CreateAssetMenu(fileName = "AnimationLockBoolAction", menuName = "Ai/Action/AnimationLockBoolAction")]
    public class AnimationLockBoolAction : AnimationAction
    {
        [SerializeField] private bool boolValue = true;
        
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            aiContextMdl.animator.SetBool(variableAnimationName, boolValue);
            return ActionStatus.Done;
        }
    }
}