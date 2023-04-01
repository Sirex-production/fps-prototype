using Entitas;
using UnityEngine;

namespace Ingame.Camerawork.Sys
{
	public sealed class RotateCameraDueToPlayerMovementSystem : IExecuteSystem
	{
		public void Execute()
		{
			var mainCameraEntity = Contexts.sharedInstance.gameplay.mainCameraTagEntity;
			var moveInput = Contexts.sharedInstance.app.inputCmp.moveInput;

			if(!mainCameraEntity.hasCameraMdl || !mainCameraEntity.hasTransformMdl)
				return;

			var transformMdl = mainCameraEntity.transformMdl;
			var destinationLocalRotation = transformMdl.initialLocalRotation * GetCameraRotationOffsetDueToMovement(moveInput);

			transformMdl.transform.localRotation = Quaternion.Slerp
			(
				transformMdl.transform.localRotation,
				destinationLocalRotation,
				1f - Mathf.Pow(.0001f, Time.deltaTime)
			);
		}

		private Quaternion GetCameraRotationOffsetDueToMovement(in Vector2 movementInput)
		{
			float zRotationOffset = -movementInput.x * 3f;

			return Quaternion.AngleAxis(zRotationOffset, Vector3.forward);
		}
	}
}