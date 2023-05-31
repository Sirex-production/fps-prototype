using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Gunplay.UI
{
	[Gameplay, Unique]
	public sealed class UiPlayerGunsViewMdl : IComponent
	{
		public UiPlayerGunsView gunsView;
	}
}