using Entitas;
using Ingame.ConfigProvision;
using UnityEngine;

namespace Ingame.Player.Movement
{
	public sealed class ConvertInputToVelocitySys : IExecuteSystem
	{
		private readonly PlayerConfig _playerConfig;
		
		private readonly AppContext _appContext;
		private readonly IGroup<GameplayEntity> _playerGroup;
		
		public ConvertInputToVelocitySys(ConfigProvider configProvider)
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			var playerMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.TransformMdl,
				GameplayMatcher.VelocityCmp,
				GameplayMatcher.GroundCheckCmp,
				GameplayMatcher.PlayerCmp
			);

			_playerConfig = configProvider.playerConfig;
			_appContext = Contexts.sharedInstance.app;
			_playerGroup = gameplayContext.GetGroup(playerMatcher);
		}

		public void Execute()
		{
			var inputCmp = _appContext.inputCmp;
			var playerEntity = _playerGroup.GetSingleEntity();
			var transformMdl = playerEntity.transformMdl;
			var groundCheckCmp = playerEntity.groundCheckCmp;
			var velocityCmp = playerEntity.velocityCmp;
			var movementVector = transformMdl.transform.forward * inputCmp.moveInput.y;
			movementVector += transformMdl.transform.right * inputCmp.moveInput.x;
			movementVector = movementVector.normalized;

			velocityCmp.currentVelocity = Vector3.Lerp(velocityCmp.currentVelocity, velocityCmp.currentVelocity + movementVector * _playerConfig.AccelerationSpeed, 1f - Mathf.Pow(_playerConfig.AccelerationDumping, Time.deltaTime));

			if (!inputCmp.jumpInput || !groundCheckCmp.IsGrounded())
				return;

			playerEntity.velocityCmp.currentVelocity += Vector3.up * _playerConfig.JumpForce;
		}
	}
}