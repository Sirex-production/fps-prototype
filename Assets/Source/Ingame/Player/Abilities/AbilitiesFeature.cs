using Ingame.ConfigProvision;
using Ingame.Player.Abilities.UI;

namespace Ingame.Player.Abilities
{
	public sealed class AbilitiesFeature : Feature
	{
		public AbilitiesFeature(ConfigProvider configProvider)
		{
			Add(new UpdatePlayerAbilitiesUiSystem(configProvider));
		}
	}
}