using UnityEngine;

namespace Ingame.Camerawork
{
	[CreateAssetMenu(menuName = "Configs/Camerawork")]
	public sealed class CameraworkConfig : ScriptableObject
	{
		[SerializeField] [Range(0f, 100f)] private float defaultCameraFov = 60f;
		[SerializeField] [Range(0f, 100f)] private float defaultHudCameraFov = 50f;

		public float DefaultCameraFov => defaultCameraFov;
		public float DefaultHudCameraFov => defaultHudCameraFov;
	}
}