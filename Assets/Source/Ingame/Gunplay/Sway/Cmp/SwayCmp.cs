using Entitas;
using UnityEngine;

namespace Ingame.Gunplay.Sway
{
	[Gameplay]
	public sealed class SwayCmp : IComponent
	{
		public AnimationCurve bobbingCurveY;
		
		public float rotationDumping;
		public float movementDumping;
		
		public float rotationSwayForce;
		public float movementSwayForce;
	}
}