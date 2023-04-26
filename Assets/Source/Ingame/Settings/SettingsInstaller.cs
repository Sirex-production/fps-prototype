using Ingame.Settings.Service;
using Zenject;

namespace Source.Ingame.Settings
{
	public sealed class SettingsInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<GameSettingsService>()
				.FromNew()
				.AsSingle();
		}
	}
}