using Entitas;
using UnityEngine;

namespace Ingame.Camerawork.Sys
{
	public sealed class RotateCameraDueToPlayerMovementSystem : IExecuteSystem
	{
		public void Execute()
		{
			var mainVirtualCameraEntity = Contexts.sharedInstance.gameplay.mainVirtualCameraTagEntity;
			var moveInput = Contexts.sharedInstance.app.inputCmp.moveInput;

			if(!mainVirtualCameraEntity.hasCinemachineVirtualCameraMdl || !mainVirtualCameraEntity.hasTransformMdl)
				return;

			var transformMdl = mainVirtualCameraEntity.transformMdl;
			var destinationLocalRotation = transformMdl.initialLocalRotation * GetCameraRotationOffsetDueToMovement(moveInput);

			transformMdl.transform.localRotation = Quaternion.Slerp
			(
				transformMdl.transform.localRotation,
				destinationLocalRotation,
				1f - Mathf.Pow(.00001f, Time.deltaTime)
			);
		}

		private Quaternion GetCameraRotationOffsetDueToMovement(in Vector2 movementInput)
		{
			float zRotationOffset = -movementInput.x * 1.5f;

			return Quaternion.AngleAxis(zRotationOffset, Vector3.forward);
		}
	}
}