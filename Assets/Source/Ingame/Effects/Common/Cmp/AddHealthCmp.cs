using Entitas;

namespace Ingame.Effects
{
	[Gameplay]
	public sealed class AddHealthCmp : IComponent
	{
		public float amountOfHealth;
	}
}