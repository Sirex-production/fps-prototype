using Ingame.PauseMenu.UI;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.PauseMenu
{
	public sealed class UiPauseMenuBaker : MonoBehaviour
	{
		[BoxGroup("UiPauseMenuModel")]
		[Required, SerializeField] private UiPauseMenu uiPauseMenu;
		
		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			entity.AddUiPauseMenuModel(uiPauseMenu);
		}
	}
}