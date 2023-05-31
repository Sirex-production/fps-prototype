using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Player.Abilities.Hook
{
	[Gameplay, Unique]
	public sealed class HookCmp : IComponent
	{
		public float cooldown;
		public float speed;
		
		public float targetDetectionAngle;
		
		public float timePassedSinceLastUsage;
		public float timePassedFlying;
	}
}