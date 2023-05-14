using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.DeadScreen
{
	public sealed class UiDeadScreenBaker : MonoBehaviour
	{
		[BoxGroup("UiPauseMenuModel")]
		[Required, SerializeField] private UiDeadScreen uiDeadScreen;
		
		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			entity.AddUiDeadScreenMdl(uiDeadScreen);
		}
	}
}