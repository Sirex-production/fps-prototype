using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [CreateAssetMenu(fileName = "AnimationChasePlayerAction", menuName = "Ai/Action/AnimationChasePlayerAction")]

    public sealed class AnimationChasePlayerAction : ChasePlayerAction
    {
        [SerializeField]
        private bool isMovedByAnimation;
        
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            if (!isMovedByAnimation)
            {
                aiContextMdl.navMeshAgent.updatePosition = true;
            }
            
            var status = base.Run(aiContextMdl);
            aiContextMdl.animator.SetBool(IsWalking, status == ActionStatus.Running);
          /*Debug.Log();*/
            return status;
        }
    }
}