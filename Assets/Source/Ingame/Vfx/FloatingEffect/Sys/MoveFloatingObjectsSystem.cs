using Entitas;
using UnityEngine;

namespace Ingame.Vfx.ShotTrail.FloatingEffect
{
	public sealed class MoveFloatingObjectsSystem : IExecuteSystem
	{
		private readonly IGroup<GameplayEntity> _floatingObjectGroup;

		public MoveFloatingObjectsSystem()
		{
			var floatingObjectMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.TransformMdl,
				GameplayMatcher.FloatingItemEffectCmp
			);

			_floatingObjectGroup = Contexts.sharedInstance.gameplay.GetGroup(floatingObjectMatcher);
		}
		
		public void Execute()
		{
			foreach(var entity in _floatingObjectGroup)
			{
				var transformMdl = entity.transformMdl;
				var itemFloatingEffectCmp = entity.floatingItemEffectCmp;

				itemFloatingEffectCmp.currentFloatingTime += Time.deltaTime * itemFloatingEffectCmp.speed;

				float sinFloatingTime = Mathf.Abs(Mathf.Cos(itemFloatingEffectCmp.currentFloatingTime));
				var currentOffset = itemFloatingEffectCmp.floatingCurve.Evaluate(sinFloatingTime) * itemFloatingEffectCmp.strength;
				var targetLocalPosition = transformMdl.initialLocalPosition + currentOffset * Vector3.up;
				
				transformMdl.transform.localPosition = targetLocalPosition;
				transformMdl.transform.Rotate(Vector3.up, itemFloatingEffectCmp.rotationSpeed * Time.deltaTime, Space.World);
			}
		}
	}
}