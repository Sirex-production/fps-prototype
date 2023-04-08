namespace Ingame.Vfx.ShotTrail
{
	public sealed class VfxFeature : Feature
	{
		public VfxFeature()
		{
			Add(new DrawShotTrailSystem());
		}
	}
}