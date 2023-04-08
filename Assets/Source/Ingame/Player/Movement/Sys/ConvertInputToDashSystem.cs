using Entitas;
using Ingame.ConfigProvision;
using UnityEngine;

namespace Ingame.Player.Movement
{
	public sealed class ConvertInputToDashSystem : IExecuteSystem
	{
		private readonly PlayerConfig _playerConfig;
		
		public ConvertInputToDashSystem(ConfigProvider configProvider)
		{
			_playerConfig = configProvider.playerConfig;
		}
		
		public void Execute()
		{
			var inputCmp = Contexts.sharedInstance.app.inputCmp;
			var playerEntity = Contexts.sharedInstance.gameplay.playerCmpEntity;
			
			if(!playerEntity.hasDashingCmp)
				return;

			var dashingCmp = playerEntity.dashingCmp;

			if(playerEntity.hasIsDashingTag)
			{
				dashingCmp.currentDashDuration += Time.deltaTime;

				if(dashingCmp.currentDashDuration >= _playerConfig.DashDuration)
				{
					playerEntity.hasIsDashingTag = false;

					dashingCmp.currentDashDuration = 0f;
					dashingCmp.timePassedSinceLastDash = 0f;
				}

				return;
			}

			dashingCmp.timePassedSinceLastDash += Time.deltaTime;

			if(!inputCmp.dashInput || dashingCmp.timePassedSinceLastDash < _playerConfig.DashCooldown)
				return;

			var dashInput = inputCmp.moveInput.sqrMagnitude < .0001f ? new Vector2(0f, 1f) : inputCmp.moveInput;
			var playerTransform = playerEntity.transformMdl.transform;
			var dashVelocity = playerTransform.forward * dashInput.y + playerTransform.right * dashInput.x;
			dashVelocity.y = 0;
			dashVelocity = dashVelocity.normalized * _playerConfig.DashSpeed;

			dashingCmp.dashingVelocity = dashVelocity;
			playerEntity.hasIsDashingTag = true;
		}
	}
}