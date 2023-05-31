using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Gunplay.MeleeAttack
{
	[Gameplay, Event(EventTarget.Self), Cleanup(CleanupMode.DestroyEntity)]
	public sealed class PerformMeleeAttackReq : IComponent
	{
		public float range;
		public float damage;
	}
}