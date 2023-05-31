using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

namespace Ingame.Vfx.ShotTrail
{
	public sealed class DashPostProcessingBaker : MonoBehaviour
	{
		[BoxGroup("PostProcessingVolumeMdl")]
		[Required, SerializeField] private Volume dashPostProcessingVolume;
		
		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			entity.AddPostProcessingVolumeMdl(dashPostProcessingVolume);
			entity.hasDashPostProcessingVolumeTag = true;
		}
	}
}