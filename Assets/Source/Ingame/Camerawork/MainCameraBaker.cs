using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Camerawork
{
	public sealed class MainCameraBaker : MonoBehaviour
	{
		[BoxGroup("CameraMdl")]
		[Required, SerializeField] private Camera mainCamera;

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			entity.AddTransformMdl(transform, transform.localRotation, transform.localPosition);
			entity.AddCameraMdl(mainCamera);
			entity.hasMainCameraTag = true;
		}
	}
}