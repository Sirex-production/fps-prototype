using Entitas;

namespace Source.Ingame.Health.Cmp
{
    [Gameplay]
    public sealed class HealthCmp : IComponent
    {
        public float healthPoints;
    }
}