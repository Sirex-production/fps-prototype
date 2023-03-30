
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    public abstract class AnimationAction : ActionBase
    {
        private static readonly string[] _animationVariablesNames = new[]{ 
            "IsAttacking",
            "IsDodging", 
        };

        private static Dictionary<string, int> _cashedAnimationVariables;
        public static Dictionary<string, int> CashedAnimationVariables
        {
            get
            {
                _cashedAnimationVariables ??= _animationVariablesNames.ToDictionary(e => e, Animator.StringToHash);
                return _cashedAnimationVariables;
            }
        }
        
        [Dropdown("_animationVariablesNames")]
        [SerializeField]
        protected string variableAnimationName;
        
    }
}