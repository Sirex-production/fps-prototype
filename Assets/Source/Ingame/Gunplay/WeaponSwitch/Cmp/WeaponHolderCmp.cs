using EcsSupport.UnityIntegration;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Gunplay.Sway.WeaponSwitch
{
	[Gameplay, Unique]
	public sealed class WeaponHolderCmp : IComponent
	{
		public GameplayEntityReference[] weapons;
		public int currentWeaponIndex;

		public GameplayEntity CurrentWeaponEntity => weapons[currentWeaponIndex].attachedEntity;
	}
}