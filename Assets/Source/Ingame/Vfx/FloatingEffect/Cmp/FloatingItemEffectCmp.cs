using Entitas;
using UnityEngine;

namespace Ingame.Vfx.ShotTrail.FloatingEffect
{
	[Gameplay]
	public sealed class FloatingItemEffectCmp : IComponent
	{
		public AnimationCurve floatingCurve;
		public float speed;
		public float strength;
		
		public float rotationSpeed;

		public float currentFloatingTime;
	}
}