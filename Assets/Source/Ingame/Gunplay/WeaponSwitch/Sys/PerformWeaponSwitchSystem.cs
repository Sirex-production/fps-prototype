using System;
using System.Collections.Generic;
using Entitas;
using Ingame.Gunplay.WeaponSwitch.Cmp;
using UnityEngine;

namespace Ingame.Gunplay.Sway.WeaponSwitch
{
	public sealed class PerformWeaponSwitchSystem : ReactiveSystem<GameplayEntity>
	{
		public PerformWeaponSwitchSystem(IContext<GameplayEntity> context) : base(context) { }

		protected override ICollector<GameplayEntity> GetTrigger(IContext<GameplayEntity> context)
		{
			return context.CreateCollector(GameplayMatcher.WeaponSwitchEvent.Added());
		}

		protected override bool Filter(GameplayEntity entity)
		{
			return true;
		}

		protected override void Execute(List<GameplayEntity> entities)
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			
			if(!gameplayContext.hasWeaponHolderCmp || !gameplayContext.hasAwaitingWeaponSwitchReq)
				return;

			var awaitingWeaponSwitchReq = gameplayContext.awaitingWeaponSwitchReq;
			var weaponHolderCmp = Contexts.sharedInstance.gameplay.weaponHolderCmp;

			if(weaponHolderCmp.weapons.Length < 2)
				return;

			HideWeapon(weaponHolderCmp.CurrentWeaponEntity);

			if(awaitingWeaponSwitchReq.switchType == AwaitingWeaponSwitchReq.SwitchType.ByIndex)
			{
				weaponHolderCmp.currentWeaponIndex = Mathf.Clamp(awaitingWeaponSwitchReq.weaponIndex - 1, 0, weaponHolderCmp.weapons.Length - 1);
				ShowWeapon(weaponHolderCmp.CurrentWeaponEntity);
				
				gameplayContext.RemoveAwaitingWeaponSwitchReq();
				
				return;
			}

			if(awaitingWeaponSwitchReq.switchType == AwaitingWeaponSwitchReq.SwitchType.Next)
			{
				weaponHolderCmp.currentWeaponIndex = ++weaponHolderCmp.currentWeaponIndex % weaponHolderCmp.weapons.Length;
				ShowWeapon(weaponHolderCmp.CurrentWeaponEntity);
				
				gameplayContext.RemoveAwaitingWeaponSwitchReq();
				
				return;
			}

			if(weaponHolderCmp.currentWeaponIndex - 1 < 0)
				weaponHolderCmp.currentWeaponIndex = weaponHolderCmp.weapons.Length - 1;
			else
				weaponHolderCmp.currentWeaponIndex -= 1;
			
			ShowWeapon(weaponHolderCmp.CurrentWeaponEntity);
			gameplayContext.RemoveAwaitingWeaponSwitchReq();
		}

		private void HideWeapon(GameplayEntity weaponEntity)
		{
			weaponEntity.hasInHangsTag = false;
			
			if(!weaponEntity.hasTransformMdl)
				return;
			
			weaponEntity.transformMdl.transform.gameObject.SetActive(false);
		}

		private void ShowWeapon(GameplayEntity weaponEntity)
		{
			weaponEntity.hasInHangsTag = true;
			
			if(!weaponEntity.hasTransformMdl)
				return;
			
			weaponEntity.transformMdl.transform.gameObject.SetActive(true);
		}
	}
}