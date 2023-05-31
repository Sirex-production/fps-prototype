using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Gunplay.WeaponSwitch
{
	[Gameplay, Cleanup(CleanupMode.DestroyEntity), FlagPrefix("has"), Event(EventTarget.Self)]
	public sealed class WeaponSwitchEvent : IComponent
	{
	
	}
}	