using Entitas;

namespace Ingame.Bullet.Sys
{
    [Gameplay]
    public sealed class ReleaseBulletReq : IComponent
    {
        public GameplayEntity gameplayEntity;
    }
}