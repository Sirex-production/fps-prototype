using Entitas;
using UnityEngine;

namespace Ingame.Effects
{
	public class AddArmorSystem : IExecuteSystem
	{
		private readonly IGroup<GameplayEntity> _armorGroup;

		public AddArmorSystem()
		{
			var healingMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.ArmorCmp,
				GameplayMatcher.AddArmorCmp
			)
			.NoneOf
			(
				GameplayMatcher.IsDeadTag
			);

			_armorGroup = Contexts.sharedInstance.gameplay.GetGroup(healingMatcher);
		}

		public void Execute()
		{
			foreach(var entity in _armorGroup)
			{
				var armorCmp = entity.armorCmp;
				var addArmorCmp = entity.addArmorCmp;

				armorCmp.currentArmor = Mathf.Max(addArmorCmp.amountOfArmor + armorCmp.currentArmor, armorCmp.maximumArmor);

				entity.RemoveAddArmorCmp();
			}
		}
	}
}