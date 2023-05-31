using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Effects.UI
{
	[Gameplay, Unique]
	public sealed class UiPlayerStatsViewMdl : IComponent
	{
		public UiPlayerStatsView uiPlayerStatsView;
	}
}