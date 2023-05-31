using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.DeadScreen
{
	[Gameplay, Unique]
	public sealed class UiDeadScreenMdl : IComponent
	{
		public UiDeadScreen uiDeadScreen;
	}
}