using Entitas;
using UnityEngine;

namespace Ingame.Player.Movement
{
	[Gameplay]
	public sealed class VelocityCmp : IComponent
	{
		public Vector3 currentVelocity;
		public float timeSpentTraveling;
	}
}