namespace Ingame.Gunplay.Sway
{
	public sealed class SwayFeature : Feature
	{
		public SwayFeature()
		{
			Add(new SwayWeaponSystem());
			Add(new MoveWeaponDueToBobbingSystem());
		}
	}
}