using Entitas;
using UnityEngine;

namespace Ingame.Player.Movement
{
	[Gameplay]
	public sealed class GroundCheckCmp : IComponent
	{
		public Transform raycastOrigin;
		public float distance;
		public float sphereCastRadius;
		public bool wasGroundedPreviousFrame;

		public bool IsGrounded()
		{
			var raycastRay = new Ray(raycastOrigin.position, raycastOrigin.forward);
			int raycastMask = ~LayerMask.GetMask("Ignore Raycast", "Player");

			return Physics.SphereCast(raycastRay, sphereCastRadius, distance, raycastMask, QueryTriggerInteraction.Ignore);
		}
	}
}