using Entitas;
using Ingame.ConfigProvision;
using UnityEngine;

namespace Ingame.Player.Movement
{
	public sealed class MoveObjectDueToVelocitySystem : IExecuteSystem
	{
		private readonly IGroup<GameplayEntity> _velocityGroup;
		private readonly PlayerConfig _playerConfig;

		public MoveObjectDueToVelocitySystem(ConfigProvider configProvider)
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			var velocityMatcher = GameplayMatcher.CharacterControllerMdl;

			_playerConfig = configProvider.playerConfig;
			_velocityGroup = gameplayContext.GetGroup(velocityMatcher);
		}
		
		public void Execute()
		{
			foreach (var entity in _velocityGroup)
			{
				var characterController = entity.characterControllerMdl.characterController;

				if(entity.hasIsSlidingTag && entity.hasSlidingCmp)
				{
					var slidingCmp = entity.slidingCmp;
					var slidingVelocity = slidingCmp.slidingDirection * _playerConfig.SlidingSpeed;
					slidingVelocity.y = -10f;
					
					characterController.Move(slidingVelocity * Time.deltaTime);

					return;
				}

				if(entity.hasIsDashingTag && entity.hasDashingCmp)
				{
					var dashingCmp = entity.dashingCmp;
					characterController.Move(dashingCmp.dashingVelocity * Time.deltaTime);
					
					return;
				}

				if(!entity.hasVelocityCmp)
					return;
					
				var velocityCmp = entity.velocityCmp;
				characterController.Move(velocityCmp.currentVelocity * Time.deltaTime);
			}
		}
	}
}