using Entitas;
using UnityEngine;

namespace EcsSupport.UnityIntegration.Models
{
	[Gameplay]
	public sealed class TransformMdl : IComponent
	{
		public Transform transform;
		public Quaternion initialLocalRotation;
		public Vector3 initialLocalPosition;
	}
}