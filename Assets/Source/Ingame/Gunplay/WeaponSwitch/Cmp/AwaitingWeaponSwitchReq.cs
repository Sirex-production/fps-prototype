using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Gunplay.WeaponSwitch.Cmp
{
	[Gameplay, Unique, FlagPrefix("has")]
	public sealed class AwaitingWeaponSwitchReq : IComponent
	{
		public enum SwitchType
		{
			Next,
			Prev
		};

		public SwitchType switchType;
	}
}