using Ingame.ConfigProvision;

namespace Ingame.Player.Movement
{
	public sealed class PlayerMovementFeature : Feature
	{
		public PlayerMovementFeature(ConfigProvider configProvider)
		{
			Add(new ConvertInputToVelocitySys(configProvider));
			Add(new ApplyGravitySys(configProvider));
			Add(new ApplyFrictionSys(configProvider));
			Add(new RotatePlayerSys());
		}
	}
}