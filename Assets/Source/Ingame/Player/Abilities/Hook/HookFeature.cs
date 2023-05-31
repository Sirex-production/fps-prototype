namespace Ingame.Player.Abilities.Hook
{
	public sealed class HookFeature : Feature
	{
		public HookFeature()
		{
			Add(new FindClosestHookTargetSystem());
		}
	}
}