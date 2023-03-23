using Ingame.Ai.FSM.State;
using NaughtyAttributes;
using UnityEngine;

namespace Ingame.Ai
{
    [CreateAssetMenu(fileName = "AiConfig", menuName = "Ai/AiConfig")]
    public sealed class AiConfig : ScriptableObject
    {
        [Header("Health")] 
        [SerializeField]
        [Min(0)]
        private float maxHealth;

        [Header("FSM")] 
        [Required]
        [SerializeField]
        private StateBase initState;


        public float MaxHealth => maxHealth;

        public StateBase InitState => initState;
    }
}