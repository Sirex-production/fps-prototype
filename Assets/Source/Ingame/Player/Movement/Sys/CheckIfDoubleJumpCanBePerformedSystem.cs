using Entitas;

namespace Ingame.Player.Movement
{
	public sealed class CheckIfDoubleJumpCanBePerformedSystem : IExecuteSystem
	{
		public void Execute()
		{
			var playerEntity = Contexts.sharedInstance.gameplay.playerCmpEntity;
			var groundCheckCmp = playerEntity.groundCheckCmp;
			bool isGrounded = groundCheckCmp.IsGrounded();

			if(isGrounded)
				playerEntity.hasCanPerformDoubleJumpTag = false;
			else if(groundCheckCmp.wasGroundedPreviousFrame) 
				playerEntity.hasCanPerformDoubleJumpTag = true;

			groundCheckCmp.wasGroundedPreviousFrame = isGrounded;
		}
	}
}