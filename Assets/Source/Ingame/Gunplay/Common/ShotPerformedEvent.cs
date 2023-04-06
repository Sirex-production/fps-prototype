using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Gunplay.Common
{
	[Gameplay, Cleanup(CleanupMode.DestroyEntity), Unique, FlagPrefix("has")]
	public sealed class ShotPerformedEvent : IComponent
	{
		
	}
}