using Ingame.Camerawork;
using Ingame.Player;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.ConfigProvision
{
	public sealed class ConfigProviderInstaller : MonoInstaller
	{
		[Required, SerializeField] private PlayerConfig playerConfig;
		[Required, SerializeField] private CameraworkConfig cameraworkConfig;

		private ConfigProvider _configProvider;
		
		public override void InstallBindings()
		{
			_configProvider = new ConfigProvider(playerConfig, cameraworkConfig);

			Container.Bind<ConfigProvider>()
				.FromInstance(_configProvider)
				.AsSingle();
		}
	}
}