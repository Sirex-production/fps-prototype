using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.ObjectPooling
{
	/// <summary>
	/// Use this tag to identify entities that are ready to be reused. 
	/// </summary>
	[Gameplay, FlagPrefix("has")]
	public sealed class FreeToReuseTag : IComponent
	{
		
	}
}