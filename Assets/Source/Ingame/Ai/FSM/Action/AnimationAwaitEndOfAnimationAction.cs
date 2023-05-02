using System.Collections.Generic;
using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [CreateAssetMenu(fileName = "AnimationAwaitEndOfAnimation", menuName = "Ai/Action/AnimationAwaitEndOfAnimationAction")]
    public sealed class AnimationAwaitEndOfAnimationAction : ActionBase
    {
        [SerializeField] private string stateName;
        private Dictionary<AiContextMdl, bool> _cashedStateAnimators = new();

        private bool AnimatorIsPlaying(Animator animator){
            return animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
 
                        animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
        }
        
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            var animator = aiContextMdl.animator;

            if (animator.GetCurrentAnimatorStateInfo(0).IsName(stateName))
            {
                if(!_cashedStateAnimators.ContainsKey(aiContextMdl))
                    _cashedStateAnimators.Add(aiContextMdl, false);

                if (!(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.98f)) 
                    return ActionStatus.Running;
                
                _cashedStateAnimators.Remove(aiContextMdl);
                return ActionStatus.Done;
            }

            if (!_cashedStateAnimators.ContainsKey(aiContextMdl)) 
                return ActionStatus.Running;
                
            _cashedStateAnimators.Remove(aiContextMdl);
            return ActionStatus.Done;
        }
    }
}