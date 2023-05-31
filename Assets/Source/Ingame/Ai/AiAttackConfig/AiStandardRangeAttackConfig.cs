using Source.Ingame.Bullet.Service;
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
            
            var player = aiBaker.Entity.aiContextMdl.player;
            var weaponPosition = aiBaker.Weapon.position;
            var direction = (player.position -  weaponPosition).normalized;
         
            BulletService.Instance.SpawnBullet(aiBaker.AIConfig.BulletBasic.GetType(),aiBaker.Weapon.transform,direction,20f, aiBaker.AIConfig.AttackDamage);
        }
    }
}