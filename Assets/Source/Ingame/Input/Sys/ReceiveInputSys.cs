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

			inputCmp.moveInput = moveInput;
			inputCmp.rotateInput = rotateInput;
			inputCmp.jumpInput = jumpInput;
			inputCmp.dashInput = dashInput;
		}

		private void ReceiveCombatInput(InputCmp inputCmp)
		{
			bool nextWeaponInput = _inputActions.Combat.NextWeapon.WasPerformedThisFrame();
			bool prevWeaponInput = _inputActions.Combat.PrevWeapon.WasPerformedThisFrame();
			bool shootHoldInput = _inputActions.Combat.Shoot.IsPressed();
			bool shootTapInput = _inputActions.Combat.Shoot.WasPerformedThisFrame();

			inputCmp.nextWeaponInput = nextWeaponInput;
			inputCmp.prevWeaponInput = prevWeaponInput;
			inputCmp.shootHoldInput = shootHoldInput;
			inputCmp.shootTapInput = shootTapInput;
		}
	}
}