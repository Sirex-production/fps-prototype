using Entitas;
using UnityEngine;

namespace EcsSupport.UnityIntegration.Models
{
	[Gameplay]
	public sealed class RigidbodyMdl : IComponent
	{
		public Rigidbody rigidbody;
	}
}