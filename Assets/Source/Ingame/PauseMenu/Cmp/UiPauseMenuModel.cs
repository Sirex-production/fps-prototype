using Entitas;
using Entitas.CodeGeneration.Attributes;
using Ingame.PauseMenu.UI;

namespace Ingame.PauseMenu
{
	[Gameplay, Unique]
	public sealed class UiPauseMenuModel : IComponent
	{
		public UiPauseMenu uiPauseMenu;
	}
}