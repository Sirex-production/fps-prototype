using Zenject;

namespace Ingame.Input
{
	public sealed class InputInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<InputActions>()
				.FromNew()
				.AsSingle();
		}
	}
}