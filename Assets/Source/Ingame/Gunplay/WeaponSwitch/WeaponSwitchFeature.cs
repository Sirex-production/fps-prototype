using Ingame.Gunplay.UI;

namespace Ingame.Gunplay.Sway.WeaponSwitch
{
	public sealed class WeaponSwitchFeature : Feature
	{
		public WeaponSwitchFeature()
		{
			Add(new InvokeWeaponSwitchAnimation());
			Add(new PerformWeaponSwitchSystem(Contexts.sharedInstance.gameplay));
			Add(new UpdatePlayerGunsUiSystem());
		}
	}
}