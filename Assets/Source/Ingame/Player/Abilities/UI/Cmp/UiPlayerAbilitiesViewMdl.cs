using Entitas.CodeGeneration.Attributes;
using Entitas;

namespace Ingame.Player.Abilities.UI
{
	[Gameplay, Unique]
	public sealed class UiPlayerAbilitiesViewMdl : IComponent
	{
		public UiPlayerAbilitiesView abilitiesView;
	}
}