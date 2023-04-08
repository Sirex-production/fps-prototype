using System;
using System.Collections.Generic;
using Ingame.Ai.FSM.AiAttackConfig;
using NaughtyAttributes;
using UnityEngine;

namespace Ingame.Ai.FSM
{
    [RequireComponent(typeof(AiBaker))]
    public sealed class AiEventHandler : MonoBehaviour
    {
        [Required] 
        [SerializeField]
        private AiAttackBaseConfig attackPattern;

        [Required]
        [SerializeField]
        private AiBaker aiBaker;
        
        private readonly Dictionary<string, int> _cashedAnimationToHash = new ();
        private Animator _animator;

        private void Awake()
        {
            _animator = aiBaker.Animator;
        }

        private void ReleaseAnimation(string animationName)
        {
            if(!_cashedAnimationToHash.ContainsKey(animationName))
                _cashedAnimationToHash.Add(animationName, Animator.StringToHash(animationName));
            
            _animator.SetBool(_cashedAnimationToHash[animationName], false);
        }

        private void Attack()
        {
            attackPattern.Attack(aiBaker);
        }
    }
}