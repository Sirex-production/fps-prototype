using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Player.Abilities.Hook
{
	[Gameplay, Unique, FlagPrefix("has")]
	public sealed class CurrentHookTargetTag : IComponent
	{
		
	}
}