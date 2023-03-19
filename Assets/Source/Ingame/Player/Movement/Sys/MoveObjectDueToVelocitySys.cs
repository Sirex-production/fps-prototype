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
			var velocityMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.CharacterControllerMdl,
				GameplayMatcher.VelocityCmp
			);

			_velocityGroup = gameplayContext.GetGroup(velocityMatcher);
		}
		
		public void Execute()
		{
			foreach (var entity in _velocityGroup)
			{
				var characterController = entity.characterControllerMdl.characterController;
				var velocityCmp = entity.velocityCmp;

				characterController.Move(velocityCmp.currentVelocity * Time.fixedDeltaTime);
			}
		}
	}
}