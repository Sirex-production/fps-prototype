using Entitas;
using UnityEngine;

namespace Ingame.Effects
{
	public class AddArmorSystem : IExecuteSystem
	{
		private readonly IGroup<GameplayEntity> _armorGroup;

		public AddArmorSystem()
		{
			var armorMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.ArmorCmp,
				GameplayMatcher.AddArmorCmp
			)
			.NoneOf
			(
				GameplayMatcher.IsDeadTag
			);

			_armorGroup = Contexts.sharedInstance.gameplay.GetGroup(armorMatcher);
		}

		public void Execute()
		{
			foreach(var entity in _armorGroup.GetEntities())
			{
				var armorCmp = entity.armorCmp;
				var addArmorCmp = entity.addArmorCmp;

				armorCmp.currentArmor = Mathf.Min(addArmorCmp.amountOfArmor + armorCmp.currentArmor, armorCmp.maximumArmor);
			
				entity.RemoveAddArmorCmp();
			}
		}
	}
}