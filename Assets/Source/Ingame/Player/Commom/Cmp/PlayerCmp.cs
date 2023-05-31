using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Player.Common
{
	[Gameplay, Unique, FlagPrefix("has")]
	public sealed class PlayerCmp : IComponent
	{
	}
}