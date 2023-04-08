using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Source.Ingame.Health.Cmp
{
    [Gameplay, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class TakeDamageRequest : IComponent
    {
        public float damageDealt;
        public IEntity target;
    }
}