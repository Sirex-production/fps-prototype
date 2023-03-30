using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [CreateAssetMenu(fileName = "AnimationAwaitAttackAction", menuName = "Ai/Action/AnimationAwaitAttackAction")]
    public sealed class AnimationAwaitAttackAction : ActionBase
    {
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            var resp = aiContextMdl.animator.GetBool(IsAttacking);
            return resp ? ActionStatus.Running : ActionStatus.Done;
        }
    }
}