using Ingame.Camerawork.Sys;

namespace Ingame.Camerawork
{
	public sealed class CameraworkFeature : Feature
	{
		public CameraworkFeature()
		{
			Add(new RotateCameraDueToPlayerMovementSystem());
		}
	}
}