using Ingame.ConfigProvision;

namespace Ingame.Player.Movement
{
	public sealed class PlayerMovementFeature : Feature
	{
		public PlayerMovementFeature(ConfigProvider configProvider)
		{
			Add(new CheckIfDoubleJumpCanBePerformedSystem());
			Add(new ConvertInputToDashSystem(configProvider));
			Add(new ConvertInputToSlidingSystem(configProvider));
			Add(new ConvertInputToVelocitySys(configProvider));
			Add(new ApplyGravitySys(configProvider));
			Add(new ApplyFrictionSys(configProvider));
			Add(new RotatePlayerSys());
			Add(new ChangePlayerHeightSystem(configProvider));
			Add(new UpdateSlidingDueToTimeSystem(configProvider));
			Add(new UpdateTravelTimeSystem());
			Add(new MoveObjectDueToVelocitySystem(configProvider));
		}
	}
}