using Ingame.ConfigProvision;
using Ingame.Player.Abilities.Magnet;
using Ingame.Player.Abilities.UI;

namespace Ingame.Player.Abilities
{
	public sealed class AbilitiesFeature : Feature
	{
		public AbilitiesFeature(ConfigProvider configProvider)
		{
			Add(new ActivateMagnetAbilitySystem());
			Add(new MoveMagneticItemsTowardsPlayerSystem());
			Add(new UpdatePlayerAbilitiesUiSystem(configProvider));
		}
	}
}