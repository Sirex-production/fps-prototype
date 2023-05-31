using Entitas;
using UnityEngine;

namespace Ingame.Player.Movement
{
	[Gameplay]
	public sealed class DashingCmp : IComponent
	{
		public Vector3 dashingVelocity;
		public float currentDashDuration;
		public float timePassedSinceLastDash;
	}
}