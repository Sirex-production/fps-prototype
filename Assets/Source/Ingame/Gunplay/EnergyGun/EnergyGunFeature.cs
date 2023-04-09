using Ingame.ConfigProvision;

namespace Ingame.Gunplay.EnergyGun
{
	public sealed class EnergyGunFeature : Feature
	{
		public EnergyGunFeature(ConfigProvider configProvider)
		{
			Add(new PerformEnergyGunShotSystem());
			Add(new ZoomAimWithEnergyRifleSystem(configProvider));
		}
	}
}