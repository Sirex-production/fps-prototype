using Ingame.Camerawork;
using Ingame.CollectableResources;
using Ingame.Player;

namespace Ingame.ConfigProvision
{
	public sealed class ConfigProvider
	{
		public readonly PlayerConfig playerConfig;
		public readonly CameraworkConfig cameraworkConfig;
		public readonly CollectableResourcesConfig collectableResourcesConfig;

		public ConfigProvider(PlayerConfig playerConfig, CameraworkConfig cameraworkConfig, CollectableResourcesConfig collectableResourcesConfig)
		{
			this.playerConfig = playerConfig;
			this.cameraworkConfig = cameraworkConfig;
			this.collectableResourcesConfig = collectableResourcesConfig;
		}
	}
}