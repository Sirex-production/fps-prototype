using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Camerawork
{
	public sealed class MainCameraBaker : MonoBehaviour
	{
		[Required, SerializeField] private Camera mainCamera;
		
		[Inject]
		private void Construct()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			var entity = gameplayContext.CreateEntity();
			
			entity.AddTransformMdl(transform, transform.localRotation, transform.position);
			entity.AddCameraMdl(mainCamera);
			entity.hasMainCameraTag = true;
		}
	}
}