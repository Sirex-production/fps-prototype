using Ingame.Player;

namespace Ingame.ConfigProvision
{
	public sealed class ConfigProvider
	{
		public readonly PlayerConfig playerConfig;

		public ConfigProvider(PlayerConfig playerConfig)
		{
			this.playerConfig = playerConfig;
		}
	}
}