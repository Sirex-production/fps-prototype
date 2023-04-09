using Entitas;
using Ingame.ConfigProvision;
using UnityEngine;

namespace Ingame.Player.Movement
{
	public sealed class ApplyGravitySys : IExecuteSystem
	{
		private readonly PlayerConfig _playerConfig;
		private readonly IGroup<GameplayEntity> _playerGroup;

		public ApplyGravitySys(ConfigProvider configProvider)
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			var playerMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.VelocityCmp,
				GameplayMatcher.GroundCheckCmp,
				GameplayMatcher.PlayerCmp
			);
			
			_playerConfig = configProvider.playerConfig;
			_playerGroup = gameplayContext.GetGroup(playerMatcher);
		}

		public void Execute()
		{
			var playerEntity = _playerGroup.GetSingleEntity();

			var groundCheck = playerEntity.groundCheckCmp; 
			var velocityCmp = playerEntity.velocityCmp;

			if (groundCheck.IsGrounded())
			{
				velocityCmp.currentVelocity.y = Mathf.Max(-5f, velocityCmp.currentVelocity.y);
				return;
			}

			velocityCmp.currentVelocity.y -= _playerConfig.GravityForce * Time.deltaTime;
		}
	}
}