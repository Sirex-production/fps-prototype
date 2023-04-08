using Entitas;

namespace Ingame.Effects
{
	[Gameplay]
	public sealed class HealthCmp : IComponent
	{
		public float initialHealth;
		public float currentHealth;
	}
}