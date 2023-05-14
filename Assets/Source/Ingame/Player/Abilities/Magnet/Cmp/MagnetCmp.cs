using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Player.Abilities.Magnet
{
	[Gameplay, Unique]
	public sealed class MagnetCmp : IComponent
	{
		public float affectDistance;
		public float strength;
	}
}