using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace EcsSupport.UnityIntegration.Physics
{
	[Gameplay, Event(EventTarget.Self), Cleanup(CleanupMode.DestroyEntity)]
	public sealed class OnCollisionExitEvent : IComponent
	{
		public Collision other;
		public Collider sender;
	}
}