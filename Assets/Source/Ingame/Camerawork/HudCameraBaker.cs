using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Camerawork
{
	public sealed class HudCameraBaker : MonoBehaviour
	{
		[BoxGroup("CameraMdl")]
		[Required, SerializeField] private Camera hudCamera;
		
		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();

			entity.hasHudCameraTag = true;
			entity.AddCameraMdl(hudCamera);
			entity.AddTransformMdl(transform, transform.localRotation, transform.localPosition);
		}
	}
}