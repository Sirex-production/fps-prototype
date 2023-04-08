using Cinemachine;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Camerawork
{
	public sealed class MainVirtualCameraBaker : MonoBehaviour
	{
		[Required, SerializeField] private CinemachineVirtualCamera mainVirtualCamera;
		
		[Inject]
		private void Construct()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			var entity = gameplayContext.CreateEntity();
			
			entity.AddTransformMdl(transform, transform.localRotation, transform.position);
			entity.AddCinemachineVirtualCameraMdl(mainVirtualCamera);
			entity.hasMainVirtualCameraTag = true;
		}
	}
}