namespace Ingame.Gunplay.Axe
{
	public sealed class AxeFeature : Feature
	{
		public AxeFeature()
		{
			Add(new InvokeAxeAnimationsSystem());
		}
	}
}