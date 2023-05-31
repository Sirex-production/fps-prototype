using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Player.Movement
{
	[Gameplay, Unique]
	public sealed class HudOriginCmp : IComponent
	{
		public float currentRotationX;
	}
}