using Entitas;
using UnityEngine;

namespace Ingame.Vfx.ShotTrail
{
	public sealed class DrawShotTrailSystem : IExecuteSystem
	{
		private readonly IGroup<GameplayEntity> _shotTrailGroup;
		private readonly Gradient _cashedColorGradient = new();
		private readonly GradientAlphaKey[] _cashedAlphaKeys = new []{new GradientAlphaKey()};

		public DrawShotTrailSystem()
		{
			var shotTrailMatcher = GameplayMatcher.ShotTrailCmp;
			_shotTrailGroup = Contexts.sharedInstance.gameplay.GetGroup(shotTrailMatcher);
		}
		
		public void Execute()
		{
			foreach(var entity in _shotTrailGroup)
			{
				var shotTrailCmp = entity.shotTrailCmp;

				shotTrailCmp.timePassedSinceDisplay += Time.deltaTime;

				if(shotTrailCmp.timePassedSinceDisplay >= shotTrailCmp.lifetime)
				{
					shotTrailCmp.lineRenderer.enabled = false;
					entity.Destroy();
					return;
				}
				
				float targetAlpha = 1f - Mathf.InverseLerp(0f, shotTrailCmp.lifetime, shotTrailCmp.timePassedSinceDisplay);

				_cashedAlphaKeys[0] = new GradientAlphaKey(targetAlpha, 0f);
				_cashedColorGradient.alphaKeys = _cashedAlphaKeys;

				shotTrailCmp.lineRenderer.enabled = true;
				shotTrailCmp.lineRenderer.SetPositions(shotTrailCmp.positions);
				shotTrailCmp.lineRenderer.colorGradient = _cashedColorGradient;
			}
		}
	}
}