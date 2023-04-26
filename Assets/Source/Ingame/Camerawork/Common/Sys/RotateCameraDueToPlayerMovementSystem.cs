using Entitas;
using UnityEngine;

namespace Ingame.Camerawork.Sys
{
	public sealed class RotateCameraDueToPlayerMovementSystem : IExecuteSystem
	{
		public void Execute()
		{
			var playerEntity = Contexts.sharedInstance.gameplay.playerCmpEntity;
			var mainVirtualCameraEntity = Contexts.sharedInstance.gameplay.mainVirtualCameraTagEntity;
			var moveInput = Contexts.sharedInstance.app.inputCmp.moveInput;
			
			if(!mainVirtualCameraEntity.hasCinemachineVirtualCameraMdl || !mainVirtualCameraEntity.hasTransformMdl)
				return;

			var transformMdl = mainVirtualCameraEntity.transformMdl;
			var targetRotation = playerEntity.hasIsSlidingTag ? GetCameraRotationDueToSliding() : GetCameraRotationOffsetDueToMovement(moveInput);
			var destinationLocalRotation = transformMdl.initialLocalRotation * targetRotation;
			
			transformMdl.transform.localRotation = Quaternion.Slerp
			(
				transformMdl.transform.localRotation,
				destinationLocalRotation,
				1f - Mathf.Pow(.00001f, Time.deltaTime)
			);
		}

		private Quaternion GetCameraRotationOffsetDueToMovement(in Vector2 movementInput)
		{
			float zRotationOffset = -movementInput.x * 2f;

			return Quaternion.AngleAxis(zRotationOffset, Vector3.forward);
		}

		private Quaternion GetCameraRotationDueToSliding()
		{
			return Quaternion.AngleAxis(15f, Vector3.forward);
		}
	}
}