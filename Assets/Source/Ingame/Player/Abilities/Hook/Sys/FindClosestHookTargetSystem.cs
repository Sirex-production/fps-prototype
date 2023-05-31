using Entitas;
using UnityEngine;

namespace Ingame.Player.Abilities.Hook
{
	public sealed class FindClosestHookTargetSystem : IExecuteSystem
	{
		private readonly IGroup<GameplayEntity> _hookTargetGroup;
		private readonly GameplayContext _gameplayContext;

		public FindClosestHookTargetSystem()
		{
			var hookTargetMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.TransformMdl,
				GameplayMatcher.HookTargetCmp
			);

			_gameplayContext = Contexts.sharedInstance.gameplay;
			_hookTargetGroup = _gameplayContext.GetGroup(hookTargetMatcher);
		}
		
		public void Execute()
		{
			if(!_gameplayContext.hasHookCmp)
				return;
			
			var playerEntity = _gameplayContext.playerCmpEntity;
			var playerTransform = playerEntity.transformMdl.transform;
			var hookCmp = _gameplayContext.hookCmp;

			foreach(var targetEntity in _hookTargetGroup)
			{
				var targetTransform = targetEntity.transformMdl.transform;
				var directionToTheTarget = targetTransform.position - playerTransform.position;
				float angleBetweenPlayerAndTarget = Vector3.Angle(playerTransform.forward, directionToTheTarget);
				
				if(angleBetweenPlayerAndTarget > hookCmp.targetDetectionAngle)
					return;

				if(_gameplayContext.hasCurrentHookTargetTag)
					_gameplayContext.currentHookTargetTagEntity.hasCurrentHookTargetTag = false;

				targetEntity.hasCurrentHookTargetTag = true;
			}
		}
	}
}