namespace Ingame.Gunplay.Projectile
{
	public sealed class ProjectileFeature : Feature
	{
		public ProjectileFeature()
		{
			Add(new MoveProjectileSystem());
			Add(new DisposeProjectileSystem());
		}
	}
}