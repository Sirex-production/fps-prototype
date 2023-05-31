namespace Ingame.Gunplay.MeleeAttack
{
	public sealed class MeleeAttackFeature : Feature
	{
		public MeleeAttackFeature()
		{
			Add(new PerformMeleeAttackSystem(Contexts.sharedInstance.gameplay));
		}
	}
}