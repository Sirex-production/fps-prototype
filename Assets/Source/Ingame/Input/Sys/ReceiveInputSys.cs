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
			_appContext.CreateEntity().AddInputCmp(Vector2.zero, Vector2.zero, false);
		}
		
		public void Execute()
		{
			foreach (var entity in _inputGroup)
			{
				ReceiveMovementInput(entity.inputCmp);
			}
		}

		private void ReceiveMovementInput(InputCmp inputCmp)
		{
			var moveInput = _inputActions.Movement.Move.ReadValue<Vector2>();
			var rotateInput = _inputActions.Movement.Rotate.ReadValue<Vector2>();
			bool jumpInput = _inputActions.Movement.Jump.WasPerformedThisFrame();

			inputCmp.moveInput = moveInput;
			inputCmp.rotateInput = rotateInput;
			inputCmp.jumpInput = jumpInput;
		}
	}
}