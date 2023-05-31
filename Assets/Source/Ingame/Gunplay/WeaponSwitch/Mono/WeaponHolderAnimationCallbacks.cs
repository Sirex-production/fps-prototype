using UnityEngine;

namespace Ingame.Gunplay.Sway.WeaponSwitch
{
	public sealed class WeaponHolderAnimationCallbacks : MonoBehaviour
	{
		public void SendWeaponSwitchSwitchEvent()
		{
			Contexts.sharedInstance.gameplay.CreateEntity().hasWeaponSwitchEvent = true;
		}
	}
}