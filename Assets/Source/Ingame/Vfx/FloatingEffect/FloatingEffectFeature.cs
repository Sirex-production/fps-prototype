namespace Ingame.Vfx.ShotTrail.FloatingEffect
{
	public sealed class FloatingEffectFeature : Feature
	{
		public FloatingEffectFeature()
		{
			Add(new MoveFloatingObjectsSystem());
		}
	}
}