using Entitas;
using UnityEngine;

namespace Ingame.Player.Movement
{
	public sealed class MoveObjectDueToVelocitySystem : IExecuteSystem
	{
		private readonly IGroup<GameplayEntity> _velocityGroup;
		
		public MoveObjectDueToVelocitySystem()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			var velocityMatcher = GameplayMatcher.CharacterControllerMdl;

			_velocityGroup = gameplayContext.GetGroup(velocityMatcher);
		}
		
		public void Execute()
		{
			foreach (var entity in _velocityGroup)
			{
				var characterController = entity.characterControllerMdl.characterController;

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