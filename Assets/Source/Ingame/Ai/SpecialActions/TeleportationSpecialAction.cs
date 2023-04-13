using NaughtyAttributes;
using UnityEngine;
 

namespace Ingame.Ai.SpecialActions
{
    [RequireComponent(typeof(AiBaker))]
    public sealed class TeleportationSpecialAction : SpecialActionBase
    {

        protected override void Act()
        {
            var enemyTransform = aiBaker.NavMeshAgent.transform;
            var newPosition = enemyTransform.position + enemyTransform.forward * Random.Range(-5, 5) + enemyTransform.right * Random.Range(-5, 5);
            
            enemyTransform.LookAt(aiBaker.Entity.aiContextMdl.player);
            enemyTransform.position = newPosition;
            aiBaker.NavMeshAgent.Warp(newPosition);
        }
    }
}