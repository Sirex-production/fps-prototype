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
        [SerializeField] private bool lockOnTarget = false;
        public override ActionStatus Run(AiContextMdl aiContextMdl)
        {
            var resp = aiContextMdl.animator.GetBool(VariableAnimationHash);
            
            if (!lockOnTarget) 
                return resp ? ActionStatus.Running : ActionStatus.Done;
            
            if (resp)
            {
                aiContextMdl.navMeshAgent.updateRotation = false;
                var transform = aiContextMdl.navMeshAgent.transform;
                
                transform.LookAt(aiContextMdl.player.position);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                
                return ActionStatus.Running;
            }
         
            aiContextMdl.navMeshAgent.updateRotation = true;
            return ActionStatus.Done;
        }
    }
}