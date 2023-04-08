using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Gunplay.EnergyGun
{
	[Gameplay, Unique]
	public sealed class EnergyGunCmp : IComponent
	{
		public float cooldownBetweenShots;
		public float timePassedSinceLastShot;
	}
}