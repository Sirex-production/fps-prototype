
using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [Serializable]
    public abstract class AnimationAction : ActionBase
    {
        [SerializeField]
        protected string variableAnimationName;

        private int _variableAnimationHash;
        private bool _isCashed;
        protected int VariableAnimationHash
        {
            get
            {
                if (_isCashed) return _variableAnimationHash;
                
                _variableAnimationHash = Animator.StringToHash(variableAnimationName);
                _isCashed = true;

                return _variableAnimationHash;
            }
        }
             
    }
}