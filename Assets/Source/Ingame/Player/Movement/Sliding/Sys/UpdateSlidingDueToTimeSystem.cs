using Entitas;
using Ingame.ConfigProvision;
using UnityEngine;

namespace Ingame.Player.Movement
{
	public sealed class UpdateSlidingDueToTimeSystem : IExecuteSystem
	{
		private readonly PlayerConfig _playerConfig;

		public UpdateSlidingDueToTimeSystem(ConfigProvider configProvider)
		{
			_playerConfig = configProvider.playerConfig;
		}
		
		public void Execute()
		{
			var playerEntity = Contexts.sharedInstance.gameplay.playerCmpEntity;
			var slidingCmp = playerEntity.slidingCmp;

			if(!playerEntity.hasIsSlidingTag)
			{
				slidingCmp.timePassedSinceLastSlide += Time.deltaTime;
				return;
			}

			slidingCmp.timePassedSinceLastSlide = 0f;
			slidingCmp.currentSlidingTime += Time.deltaTime;

			if(slidingCmp.currentSlidingTime >= _playerConfig.SlidingDuration)
			{
				playerEntity.hasIsSlidingTag = false;
				slidingCmp.currentSlidingTime = 0f;
			}
		}
	}
}