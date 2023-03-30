using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [CreateAssetMenu(fileName = "AnimationLockAttackAction", menuName = "Ai/Action/AnimationLockAttackAction")]
    public sealed class AnimationLockAttackAction : ActionBase
    {
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            aiContextMdl.animator.SetBool(IsAttacking, true);
            return ActionStatus.Done;
        }
    }
}