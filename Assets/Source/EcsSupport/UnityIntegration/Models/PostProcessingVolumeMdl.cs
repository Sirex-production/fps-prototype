using Entitas;
using UnityEngine.Rendering;

namespace EcsSupport.UnityIntegration.Models
{
	[Gameplay]
	public sealed class PostProcessingVolumeMdl : IComponent
	{
		public Volume volume;
	}
}