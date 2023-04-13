using UnityEngine;

namespace Ingame.Ai.FSM.AiAttackConfig
{
    [CreateAssetMenu(fileName = "AiBouncyExplosiveRangeAttackConfig", menuName = "Ai/Attack/AiBouncyExplosiveRangeAttackConfig")]
    public sealed class AiBouncyExplosiveRangeAttackConfig : AiAttackBaseConfig
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
            
            var directionXZ = (player.position -  weaponPosition).normalized;
            var directionY = enemy.up * 1.5f;
            
            bullet.Rigidbody.AddForce(directionXZ*2 + directionY, ForceMode.Impulse); 
           
        }
    }
}