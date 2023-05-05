namespace Ingame.PauseMenu
{
	public sealed class PauseMenuFeature : Feature
	{
		public PauseMenuFeature()
		{
			Add(new DisplayPauseMenuSystem());
		}
	}
}