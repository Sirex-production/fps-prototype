using Entitas;

namespace Ingame.Effects
{
	[Gameplay]
	public sealed class ApplyDamageCmp : IComponent
	{
		public float amountOfDamage;
	}
}