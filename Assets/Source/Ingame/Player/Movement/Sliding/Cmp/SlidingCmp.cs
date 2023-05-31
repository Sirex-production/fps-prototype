using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using IComponent = Entitas.IComponent;

namespace Ingame.Player.Movement
{
	[Gameplay, Unique]
	public sealed class SlidingCmp : IComponent
	{
		public Vector3 slidingDirection;
		public float timePassedSinceLastSlide;
		public float currentSlidingTime;
	}
}