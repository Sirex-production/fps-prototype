using Entitas;

namespace Ingame.Effects
{
	[Gameplay]
	public sealed class ArmorCmp : IComponent
	{
		public float percentageOfDamageBlockedByArmor = .25f;
		public float percentageOfArmorTaken = .25f;
		
		public float maximumArmor;
		public float currentArmor;
	}
}