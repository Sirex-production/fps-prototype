using Entitas;
using Ingame.Ai.FSM.State;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

namespace Ingame.Ai.Cmp
{
    [Gameplay]
    public sealed class AiContextMdl : IComponent
    {
        //Config 
        public NavMeshAgent navMeshAgent;
        public AiConfig aiConfig;
        public Transform player;
        public Collider playerCollider;
        public Animator animator;
        public Transform weapon;
    
        public AiStateWrapper aiStateWrapper;
        public AiAnimationWrapper aiAnimationWrapper;

    }

    public struct AiAnimationWrapper
    {
        public Vector2 smoothDeltaPosition;
        public Vector2 smoothVelocity;
    }
}