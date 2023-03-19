using Entitas;
using UnityEngine;

namespace EcsSupport.UnityIntegration.Models
{
	[Gameplay]
	public sealed class CameraMdl : IComponent
	{
		public Camera camera;
	}
}