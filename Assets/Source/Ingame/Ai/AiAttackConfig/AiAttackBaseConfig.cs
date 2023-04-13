using UnityEngine;

namespace Ingame.Ai.FSM.AiAttackConfig
{
    public abstract class AiAttackBaseConfig : ScriptableObject
    {
        public abstract void Attack(AiBaker aiBaker);
    }
}