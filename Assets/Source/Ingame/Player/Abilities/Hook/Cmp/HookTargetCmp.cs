using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Player.Abilities.Hook
{
	[Gameplay, Unique, FlagPrefix("has")]
	public sealed class HookTargetCmp : IComponent
	{
		public HookType hookType;
		
		public enum HookType
		{
			TargetTowardsPlayer,
			PlayerTowardTarget
		}
	}
}