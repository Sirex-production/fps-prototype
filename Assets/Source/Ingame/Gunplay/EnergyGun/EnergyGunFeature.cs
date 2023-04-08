namespace Ingame.Gunplay.EnergyGun
{
	public sealed class EnergyGunFeature : Feature
	{
		public EnergyGunFeature()
		{
			Add(new PerformEnergyGunShotSystem());
		}
	}
}