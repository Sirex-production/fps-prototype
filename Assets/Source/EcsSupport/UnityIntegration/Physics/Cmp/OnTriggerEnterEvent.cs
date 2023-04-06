using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace EcsSupport.UnityIntegration.Physics
{
	[Gameplay, Event(EventTarget.Self), Cleanup(CleanupMode.DestroyEntity)]
	public sealed class OnTriggerEnterEvent : IComponent
	{
		public Collider other;
		public Collider sender;
	}
}