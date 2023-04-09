using Ingame.Camerawork;
using Ingame.Player;

namespace Ingame.ConfigProvision
{
	public sealed class ConfigProvider
	{
		public readonly PlayerConfig playerConfig;
		public readonly CameraworkConfig cameraworkConfig;

		public ConfigProvider(PlayerConfig playerConfig, CameraworkConfig cameraworkConfig)
		{
			this.playerConfig = playerConfig;
			this.cameraworkConfig = cameraworkConfig;
		}
	}
}