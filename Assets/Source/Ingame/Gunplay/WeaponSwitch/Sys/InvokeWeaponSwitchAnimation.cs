using Entitas;
using Ingame.Gunplay.WeaponSwitch.Cmp;
using UnityEngine;

namespace Ingame.Gunplay.Sway.WeaponSwitch
{
	public sealed class InvokeWeaponSwitchAnimation : IExecuteSystem, IInitializeSystem
	{
		private const string SWITCH_WEAPONS_ANIMATION_TRIGGER_NAME = "SwitchWeapon";
		
		public void Initialize()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;

			if(!gameplayContext.hasWeaponHolderCmp || gameplayContext.hasAwaitingWeaponSwitchReq)
				return;
			
			var weaponHolderEntity = gameplayContext.weaponHolderCmpEntity;
			var weaponHolderCmp = weaponHolderEntity.weaponHolderCmp;
			
			if(!weaponHolderEntity.hasAnimatorMdl)
				return;
			
			var weaponHolderAnimator = weaponHolderEntity.animatorMdl.aninmator;
			var eventEntity = gameplayContext.CreateEntity();

			weaponHolderCmp.currentWeaponIndex = weaponHolderCmp.weapons.Length - 1;
			eventEntity.AddAwaitingWeaponSwitchReq(AwaitingWeaponSwitchReq.SwitchType.Next);
				
			PlayWeaponSwitchAnimation(weaponHolderAnimator);
		}
		
		public void Execute()
		{
			var gameplayContext = Contexts.sharedInstance.gameplay;
			var inputCmp = Contexts.sharedInstance.app.inputCmp;
			
			if(!gameplayContext.hasWeaponHolderCmp || gameplayContext.hasAwaitingWeaponSwitchReq)
				return;

			var weaponHolderEntity = gameplayContext.weaponHolderCmpEntity;

			if(!weaponHolderEntity.hasAnimatorMdl)
				return;

			var weaponHolderAnimator = weaponHolderEntity.animatorMdl.aninmator;
			
			if(inputCmp.nextWeaponInput)
			{
				var eventEntity = gameplayContext.CreateEntity();
				eventEntity.AddAwaitingWeaponSwitchReq(AwaitingWeaponSwitchReq.SwitchType.Next);
				
				PlayWeaponSwitchAnimation(weaponHolderAnimator);
				
				return;
			}
			
			if(inputCmp.prevWeaponInput)
			{
				var eventEntity = gameplayContext.CreateEntity();
				eventEntity.AddAwaitingWeaponSwitchReq(AwaitingWeaponSwitchReq.SwitchType.Prev);
				PlayWeaponSwitchAnimation(weaponHolderAnimator);
			}
		}

		private void PlayWeaponSwitchAnimation(Animator weaponHolderAnimator)
		{
			weaponHolderAnimator.ResetTrigger(SWITCH_WEAPONS_ANIMATION_TRIGGER_NAME);
			weaponHolderAnimator.SetTrigger(SWITCH_WEAPONS_ANIMATION_TRIGGER_NAME);
		}
	}
}