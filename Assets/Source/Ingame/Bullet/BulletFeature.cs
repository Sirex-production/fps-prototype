using Ingame.Bullet.Sys;

namespace Source.Ingame.Bullet
{
    public sealed class BulletFeature : Feature
    {
        public BulletFeature()
        {
            Add(new InitBulletSys());
            Add(new SpawnBulletSys());
            Add(new DisposeBulletSys());
        }
    }
}