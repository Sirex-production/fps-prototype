using Zenject;

namespace Ingame.Gunplay.ArrowGun
{
	public sealed class ArrowGunFeature : Feature
	{
		public ArrowGunFeature(DiContainer diContainer)
		{
			Add(new SpawnArrowProjectileSystem(diContainer));
		}
	}
}