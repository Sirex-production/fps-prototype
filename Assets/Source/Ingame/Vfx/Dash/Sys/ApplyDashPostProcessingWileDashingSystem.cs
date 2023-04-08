using Entitas;

namespace Ingame.Vfx.Dash
{
	public sealed class ApplyDashPostProcessingWileDashingSystem : IExecuteSystem
	{
		public void Execute()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;

			if(!gameplayContext.hasPlayerCmp || !gameplayContext.hasDashPostProcessingVolumeTag)
				return;

			var playerCmp = gameplayContext.playerCmpEntity;
			var dashPostProcessingEntity = gameplayContext.dashPostProcessingVolumeTagEntity;

			if(!dashPostProcessingEntity.hasPostProcessingVolumeMdl)
				return;

			var dashPostProcessingVolume = dashPostProcessingEntity.postProcessingVolumeMdl.volume;
			dashPostProcessingVolume.weight = playerCmp.hasIsDashingTag ? 1f : 0f;
		}
	}
}