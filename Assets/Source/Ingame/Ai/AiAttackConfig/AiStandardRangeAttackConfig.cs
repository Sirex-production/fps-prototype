using UnityEngine;

namespace Ingame.Ai.FSM.AiAttackConfig
{
    [CreateAssetMenu(fileName = "AiStandardRangeAttackConfig", menuName = "Ai/Attack/AiStandardRangeAttackConfig")]
    public sealed class AiStandardRangeAttackConfig : AiAttackBaseConfig
    {
        public override void Attack(AiBaker aiBaker)
        {
            if(!aiBaker.AIConfig.IsRange)
                return;

            var enemy = aiBaker.NavMeshAgent.transform;
            var player = aiBaker.Entity.aiContextMdl.player;
            
            var bullet = Instantiate(aiBaker.AIConfig.Bullet);
            var bulletTransform = bullet.transform;
            var weaponPosition = aiBaker.Weapon.position;
            
            bullet.Init(aiBaker.AIConfig);
            
            bulletTransform.position = weaponPosition;
            bulletTransform.rotation = enemy.rotation;
            
            var direction = (player.position -  weaponPosition).normalized;
            bullet.AttachedRigidbody.AddForce(direction*20, ForceMode.Impulse);
        }
    }
}