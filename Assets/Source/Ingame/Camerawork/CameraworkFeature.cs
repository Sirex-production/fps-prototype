using Ingame.Camerawork.Recoil;
using Ingame.Camerawork.Sys;
using Ingame.ConfigProvision;

namespace Ingame.Camerawork
{
	public sealed class CameraworkFeature : Feature
	{
		public CameraworkFeature(ConfigProvider configProvider)
		{
			Add(new RotateCameraDueToPlayerMovementSystem());
			Add(new UpdateCameraRecoilSystem(configProvider));
		}
	}
}