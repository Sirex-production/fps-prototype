using Ingame.Ai.Cmp;
using UnityEngine;

namespace Ingame.Ai.FSM.Action
{
    [CreateAssetMenu(fileName = "ChangeAnimationBasedOnAttackRageDistanceConditionAction", menuName = "Ai/Action/ChangeAnimationBasedOnAttackRageDistanceConditionAction")]
    public sealed class ChangeAnimationBasedOnAttackRageDistanceConditionAction : ChangeAnimationBasedOnDistanceConditionAction
    {
        protected override float GetDistance(AiContextMdl aiContextMdl)
        {
            Debug.Log(Vector3.Distance(aiContextMdl.player.position, aiContextMdl.navMeshAgent.transform.position)+"     "+aiContextMdl.aiConfig.AttackVisionRange);
            return aiContextMdl.aiConfig.AttackVisionRange;
        }
    }
}