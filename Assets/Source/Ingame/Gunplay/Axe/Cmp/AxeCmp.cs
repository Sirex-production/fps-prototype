using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Gunplay.Axe
{
	[Gameplay, Unique]
	public sealed class AxeCmp : IComponent
	{
		public float range;
		public float damage;
	}
}