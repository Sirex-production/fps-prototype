using Entitas;
using UnityEngine;

namespace Ingame.Vfx.ShotTrail
{
	[Gameplay]
	public sealed class ShotTrailCmp : IComponent
	{
		public LineRenderer lineRenderer;
		public Vector3[] positions;
		public float lifetime;

		public float timePassedSinceDisplay;
	}
}