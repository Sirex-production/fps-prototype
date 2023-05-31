using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Source.Ingame.Health.Cmp
{
    [Gameplay, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class TakeDamageReq : IComponent
    {
        public float damageDealt;
        public GameplayEntity target;
    }
}