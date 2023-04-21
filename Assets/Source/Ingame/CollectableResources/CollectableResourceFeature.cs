using Ingame.ConfigProvision;

namespace Ingame.CollectableResources
{
	public sealed class CollectableResourceFeature : Feature
	{
		public CollectableResourceFeature(ConfigProvider configProvider)
		{
			Add(new CollectResourceByPlayerSystem(configProvider));
		}
	}
}