namespace Ingame.Input
{
	public sealed class InputFeature : Feature
	{
		public InputFeature(InputActions inputActions)
		{
			Add(new ReceiveInputSys(inputActions));
		}
	}
}