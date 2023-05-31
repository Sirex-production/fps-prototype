using Entitas;
using UnityEngine;

namespace Ingame.Gunplay.Sway
{
	[Gameplay]
	public sealed class RecoilCmp : IComponent
	{
		public AnimationCurve recoilCurveX;
		public AnimationCurve recoilCurveY;
		public AnimationCurve recoilCurveZ;

		public float positionDumping;
		public float recoilStabilizationDumping;
		public float recoilGain;
		public float recoilStrength;

		public Vector2 cameraRecoilStrength;

		public float currentRecoil;
		

		public Vector3 CurrentDeltaRotation => new()
		{
			x = recoilCurveX.Evaluate(currentRecoil) * recoilStrength,
			y = recoilCurveY.Evaluate(currentRecoil) * recoilStrength,
			z = recoilCurveZ.Evaluate(currentRecoil) * recoilStrength
		};
	}
}