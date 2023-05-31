using System;
using System.Runtime.CompilerServices;
using Entitas;
using Ingame.Ai.Cmp;
using UnityEngine;
using UnityEngine.AI;

namespace Ingame.Animation.Sys
{
    public sealed class SynchronizeAiAnimationWithNavMeshSys : IExecuteSystem, IInitializeSystem
    {
        private readonly IGroup<GameplayEntity> _enemyGroup;
        
        public SynchronizeAiAnimationWithNavMeshSys()
        {
            var enemyMatcher = GameplayMatcher.AllOf(GameplayMatcher.AiContextMdl,GameplayMatcher.MovementByAnimationsTag);
            _enemyGroup = Contexts.sharedInstance.gameplay.GetGroup(enemyMatcher);
        }
        
        public void Initialize()
        {
            foreach (var enemy in _enemyGroup)
            {
                var aiMdl = enemy.aiContextMdl;
                
                aiMdl.animator.applyRootMotion = true;
                aiMdl.navMeshAgent.updatePosition = false;
                aiMdl.navMeshAgent.updateRotation = true;
            }
        }
        
        public void Execute()
        {
            foreach (var enemy in _enemyGroup)
            {
                var aiMdl = enemy.aiContextMdl;
                var animator = aiMdl.animator;
                var agent = aiMdl.navMeshAgent;
                ref var animationWrapper = ref aiMdl.aiAnimationWrapper;
                
                SynchronizeYAxis(animator, agent, ref animationWrapper);
                SynchronizeXZAxis(animator, agent, ref animationWrapper);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SynchronizeYAxis(Animator animator, NavMeshAgent navMeshAgent,ref AiAnimationWrapper animationWrapper)
        {
            var rootPosition = animator.rootPosition;
            rootPosition.y = navMeshAgent.nextPosition.y;
            animator.transform.position = rootPosition;
            navMeshAgent.nextPosition = rootPosition;
            
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SynchronizeXZAxis(Animator animator, NavMeshAgent navMeshAgent, ref AiAnimationWrapper animationWrapper)
        {
            var transform = animator.transform;
            var worldPosition = navMeshAgent.nextPosition - transform.position;
            worldPosition.y = 0;

            float deltaRight = Vector3.Dot(transform.right, worldPosition);
            float deltaForward = Vector3.Dot(transform.forward, worldPosition);
            var deltaPos = new Vector2(deltaRight, deltaForward);
            float smoothness = Mathf.Min(1, Time.deltaTime / 0.1f);
            
            animationWrapper.smoothDeltaPosition = Vector2.Lerp(animationWrapper.smoothDeltaPosition, deltaPos, smoothness);
            animationWrapper.smoothVelocity = animationWrapper.smoothDeltaPosition / Time.deltaTime;
            
            transform.position = Vector3.Lerp(animator.rootPosition, navMeshAgent.nextPosition, smoothness);
            
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                animationWrapper.smoothVelocity = Vector2.Lerp(Vector2.zero, animationWrapper.smoothVelocity,
                    navMeshAgent.remainingDistance / navMeshAgent.stoppingDistance);
            }
            
            float magnitude = worldPosition.magnitude;
            if (magnitude > navMeshAgent.radius / 2f)
            {
                transform.position = Vector3.Lerp(animator.rootPosition,navMeshAgent.nextPosition,smoothness);
            }
        }
    }
}