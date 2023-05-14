using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Source.Ingame.Settings.Core
{
	[App, Event(EventTarget.Self), Cleanup(CleanupMode.DestroyEntity)]
	public sealed class UpdateSettingsEvent : IComponent
	{
		
	}
}