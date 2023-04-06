using Entitas;
using UnityEngine;

namespace Ingame.Gunplay.Projectile
{
	public sealed class MoveProjectileSystem : IExecuteSystem
	{
		private readonly IGroup<GameplayEntity> _projectileGroup;

		public MoveProjectileSystem()
		{
			var projectileMatcher = GameplayMatcher
				.AllOf
				(
					GameplayMatcher.TransformMdl,
					GameplayMatcher.ProjectileCmp
				)
				.NoneOf
				(
					GameplayMatcher.FreeToReuseTag
				);

			_projectileGroup = Contexts.sharedInstance.gameplay.GetGroup(projectileMatcher);
		}

		public void Execute()
		{
			foreach(var entity in _projectileGroup)
			{
				var transformMdl = entity.transformMdl;
				var projectileCmp = entity.projectileCmp;
				
				transformMdl.transform.position += transformMdl.transform.forward * projectileCmp.currentSpeed * Time.deltaTime;
			}
		}
	}
}