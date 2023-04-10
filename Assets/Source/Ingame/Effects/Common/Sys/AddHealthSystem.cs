using Entitas;
using UnityEngine;

namespace Ingame.Effects
{
	public sealed class AddHealthSystem : IExecuteSystem
	{
		private readonly IGroup<GameplayEntity> _healingGroup;

		public AddHealthSystem()
		{
			var healingMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.HealthCmp,
				GameplayMatcher.AddHealthCmp
			)
			.NoneOf
			(
				GameplayMatcher.IsDeadTag
			);

			_healingGroup = Contexts.sharedInstance.gameplay.GetGroup(healingMatcher);
		}

		public void Execute()
		{
			foreach(var entity in _healingGroup)
			{
				var healthCmp = entity.healthCmp;
				var addHealthCmp = entity.addHealthCmp;
				
				healthCmp.currentHealth = Mathf.Max(addHealthCmp.amountOfHealth + healthCmp.currentHealth, healthCmp.maximumHealth);
				
				entity.RemoveAddHealthCmp();
			}
		}
	}
}