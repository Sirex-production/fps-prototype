using Entitas;
using Entitas.CodeGeneration.Attributes;
using Ingame.Settings.Service;

namespace Source.Ingame.Settings.Core
{
	[App, Unique]
	public sealed class SettingsCmp : IComponent
	{
		public SettingsData currentSettingsData;
	}
}