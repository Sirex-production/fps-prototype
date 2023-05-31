using Entitas;
using Ingame.Gunplay.Sway;
using UnityEngine;

namespace Ingame.Gunplay.ArrowGun
{
	[Gameplay]
	public sealed class ArrowSpawnerCmp : IComponent
	{
		public Transform spawnOriginTransform;
		public ArrowProjectileBaker arrowProjectilePrefab;

		public float timePassedSinceLastShot;
		public float pauseBetweenShots;
	}
}