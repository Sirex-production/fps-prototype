using EcsSupport.UnityIntegration;
using Entitas.Unity;
using Ingame.Player;
using UnityEngine;

namespace Ingame.Ai.FSM.AiAttackConfig
{
    [CreateAssetMenu(fileName = "AiStandardConeMeleeAttackConfig", menuName = "Ai/Attack/AiStandardConeMeleeAttackConfig")]
    public sealed class AiStandardConeMeleeAttackConfig : AiAttackBaseConfig
    {
        private const int HITS_NUMBER = 25;
        private RaycastHit[] _cashedHits;
        public override void Attack(AiBaker aiBaker)
        {
            var cashedEnemyTransform = aiBaker.transform;
            var cashedEnemyPosition = cashedEnemyTransform.position;
            var cashedPlayerPosition = aiBaker.Entity.aiContextMdl.player.position;
            var cashedAiConfig = aiBaker.AIConfig;
            
            float distance = Vector3.Distance(cashedPlayerPosition, cashedEnemyPosition);
            if(distance > aiBaker.AIConfig.AttackRange)
                return;

            var dir = cashedPlayerPosition - cashedEnemyPosition;
            dir.y = 0;
            
            var deltaAngle = Vector3.Angle(dir, cashedEnemyTransform.forward);
            if (deltaAngle >= cashedAiConfig.AttackAngle || deltaAngle < 0)
                return;
            
            _cashedHits ??= new RaycastHit[HITS_NUMBER];
            dir = (cashedPlayerPosition - cashedEnemyPosition).normalized;
            
            var size = Physics.RaycastNonAlloc(cashedEnemyPosition, dir, _cashedHits, distance);
            if (size <= 0)
                return;

            for (int i = 0; i < size; i++)
            {
                if (!_cashedHits[i].transform.root.TryGetComponent<GameplayEntityReference>(out var reference) || !_cashedHits[i].transform.CompareTag("Player"))
                    continue;
                
                reference.attachedEntity.AddApplyDamageCmp(cashedAiConfig.AttackDamage);
                return;
            }
        }
    }
}