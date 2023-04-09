using UnityEngine;
using Entitas;
using Ingame.ConfigProvision;

namespace Ingame.Player.Movement
{
	public sealed class ApplyFrictionSys : IExecuteSystem
	{
		private readonly PlayerConfig _playerConfig;
		private readonly IGroup<GameplayEntity> _playerGroup;

		public ApplyFrictionSys(ConfigProvider configProvider)
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			var playerMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.CharacterControllerMdl,
				GameplayMatcher.VelocityCmp,
				GameplayMatcher.PlayerCmp
			);
			
			_playerConfig = configProvider.playerConfig;
			_playerGroup = gameplayContext.GetGroup(playerMatcher);
		}

		public void Execute()
		{
			var playerEntity = _playerGroup.GetSingleEntity();
			var velocityCmp = playerEntity.velocityCmp;
			var targetVelocity = Vector3.up * velocityCmp.currentVelocity.y;
			
			velocityCmp.currentVelocity = Vector3.Lerp
			(
				velocityCmp.currentVelocity,
				targetVelocity,
				1f - Mathf.Pow(_playerConfig.FrictionDumping, Time.deltaTime)
			);
		}
	}
}