using Ingame.Player;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.ConfigProvision
{
	public sealed class ConfigProviderInstaller : MonoInstaller
	{
		[Required, SerializeField] private PlayerConfig playerConfig;

		private ConfigProvider _configProvider;
		
		public override void InstallBindings()
		{
			_configProvider = new ConfigProvider(playerConfig);

			Container.Bind<ConfigProvider>()
				.FromInstance(_configProvider)
				.AsSingle();
		}
	}
}