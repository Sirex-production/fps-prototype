using Entitas;
using Ingame.ConfigProvision;
using UnityEngine;

namespace Ingame.Player.Movement
{
	public sealed class ConvertInputToSlidingSystem : IExecuteSystem
	{
		private readonly PlayerConfig _playerConfig;

		public ConvertInputToSlidingSystem(ConfigProvider configProvider)
		{
			_playerConfig = configProvider.playerConfig;
		}
		
		public void Execute()
		{
			var inputCmp = Contexts.sharedInstance.app.inputCmp;
			var playerEntity = Contexts.sharedInstance.gameplay.playerCmpEntity;
			var slidingCmp = playerEntity.slidingCmp;

			if((inputCmp.jumpInput || playerEntity.hasIsDashingTag) && playerEntity.hasIsSlidingTag)
			{
				playerEntity.hasIsSlidingTag = false;
				return;
			}

			if(!inputCmp.slideInput || playerEntity.hasIsSlidingTag || slidingCmp.timePassedSinceLastSlide < _playerConfig.SlidingCooldown)
				return;
			
			if(playerEntity.hasGroundCheckCmp && !playerEntity.groundCheckCmp.IsGrounded())
				return;

			slidingCmp.slidingDirection = playerEntity.transformMdl.transform.forward;
			playerEntity.hasIsSlidingTag = true;
		}
	}
}