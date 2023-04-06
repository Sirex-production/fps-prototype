using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Gunplay.WeaponSwitch
{
	[Gameplay, Cleanup(CleanupMode.RemoveComponent), FlagPrefix("has"), Event(EventTarget.Self)]
	public sealed class WeaponSwitchEvent : IComponent
	{
	
	}
}