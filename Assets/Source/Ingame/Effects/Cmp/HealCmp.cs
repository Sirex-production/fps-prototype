using Entitas;

namespace Ingame.Effects
{
	[Gameplay]
	public sealed class HealCmp : IComponent
	{
		public float amountOfHealth;
	}
}