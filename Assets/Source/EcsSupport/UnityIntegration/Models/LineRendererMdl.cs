using Entitas;
using UnityEngine;

namespace EcsSupport.UnityIntegration.Models
{
	[Gameplay]
	public sealed class LineRendererMdl : IComponent
	{
		public LineRenderer lineRenderer;
	}
}