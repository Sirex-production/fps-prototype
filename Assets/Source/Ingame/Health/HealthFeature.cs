using Source.Ingame.Health.Sys;

namespace Source.Ingame.Health
{
    public sealed class HealthFeature : Feature
    {
        public HealthFeature(GameplayContext contexts)
        {
            Add(new DecreaseHealthPointsSys(contexts));
        }
    }
}