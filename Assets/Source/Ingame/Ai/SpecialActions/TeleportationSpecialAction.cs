using NaughtyAttributes;
using UnityEngine;
 

namespace Ingame.Ai.SpecialActions
{
    
    public sealed class TeleportationSpecialAction : SpecialActionBase
    {
        [SerializeField] private Transform model;
        protected override void Act()
        {
            var enemyTransform = model;
            var newPosition = enemyTransform.position + enemyTransform.forward * Random.Range(-5, 5) + enemyTransform.right * Random.Range(-5, 5);
          //  enemyTransform.LookAt(aiBaker.Entity.aiContextMdl.player);
            //enemyTransform.rotation = Quaternion.Euler(0,enemyTransform.rotation.y,0);
            enemyTransform.position = newPosition;
            aiBaker.NavMeshAgent.Warp(newPosition);
        }
    }
}