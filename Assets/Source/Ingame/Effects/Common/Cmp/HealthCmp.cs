using Entitas;

namespace Ingame.Effects
{
	[Gameplay]
	public sealed class HealthCmp : IComponent
	{
		public float maximumHealth;
		public float currentHealth;
	}
}