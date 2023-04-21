using Entitas;
using UnityEngine;

namespace Ingame.Input
{
	public sealed class ReceiveInputSys : IInitializeSystem, IExecuteSystem
	{
		private readonly InputActions _inputActions;

		private readonly AppContext _appContext;
		private readonly IGroup<AppEntity> _inputGroup;

		public ReceiveInputSys(InputActions inputActions)
		{
			_inputActions = inputActions;
			_inputActions.Enable();
			
			_appContext = Contexts.sharedInstance.app;
			_inputGroup = _appContext.GetGroup(AppMatcher.InputCmp);
		}

		public void Initialize()
		{
			_appContext.CreateEntity()
				.AddInputCmp
				(
					Vector2.zero,
					Vector2.zero,
					false,
					false,
					false,
					false,
					false,
					-1,
					false,
					false,
					false,
					false,
					 false
				);
		}

		public void Execute()
		{
			foreach (var entity in _inputGroup)
			{
				var inputCmp = entity.inputCmp;
				
				ReceiveMovementInput(inputCmp);
				ReceiveCombatInput(inputCmp);
			}
		}

		private void ReceiveMovementInput(InputCmp inputCmp)
		{
			var moveInput = _inputActions.Movement.Move.ReadValue<Vector2>();
			var rotateInput = _inputActions.Movement.Rotate.ReadValue<Vector2>();
			bool jumpInput = _inputActions.Movement.Jump.WasPerformedThisFrame();
			bool dashInput = _inputActions.Movement.Dash.WasPerformedThisFrame();
			bool slideInput = _inputActions.Movement.Sliding.WasPerformedThisFrame();

			inputCmp.moveInput = moveInput;
			inputCmp.rotateInput = rotateInput;
			inputCmp.jumpInput = jumpInput;
			inputCmp.dashInput = dashInput;
			inputCmp.slideInput = slideInput;
		}

		private void ReceiveCombatInput(InputCmp inputCmp)
		{
			bool nextWeaponInput = _inputActions.Combat.NextWeapon.WasPerformedThisFrame();
			bool prevWeaponInput = _inputActions.Combat.PrevWeapon.WasPerformedThisFrame();
			bool shootHoldInput = _inputActions.Combat.Shoot.IsPressed();
			bool shootTapInput = _inputActions.Combat.Shoot.WasPerformedThisFrame();
			bool aimHoldInput = _inputActions.Combat.Aim.IsPressed();
			bool aimTapInput = _inputActions.Combat.Aim.WasPerformedThisFrame();
			bool magnetAbilityInput = _inputActions.Combat.MagnetAbility.IsPressed();

			inputCmp.nextWeaponInput = nextWeaponInput;
			inputCmp.prevWeaponInput = prevWeaponInput;
			inputCmp.shootHoldInput = shootHoldInput;
			inputCmp.shootTapInput = shootTapInput;
			inputCmp.aimHoldInput = aimHoldInput;
			inputCmp.aimTapInput = aimTapInput;
			inputCmp.magnetAbilityInput = magnetAbilityInput;

			if(_inputActions.Combat.SelectWeaponOne.WasPerformedThisFrame())
				inputCmp.selectWeaponInput = 1;
			else if(_inputActions.Combat.SelectWeaponTwo.WasPerformedThisFrame())
				inputCmp.selectWeaponInput = 2;
			else if(_inputActions.Combat.SelectWeaponThree.WasPerformedThisFrame())
				inputCmp.selectWeaponInput = 3;
			else
				inputCmp.selectWeaponInput = -1;
		}
	}
}