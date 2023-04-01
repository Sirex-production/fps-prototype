using Entitas;
using UnityEngine;

namespace Ingame.Gunplay.Sway
{
	public sealed class SwayWeaponSystem : IExecuteSystem
	{
		private readonly IGroup<GameplayEntity> _swayObjectGroup;

		public SwayWeaponSystem()
		{
			var swayObjectMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.TransformMdl,
				GameplayMatcher.SwayCmp,
				GameplayMatcher.InHangsTag
			);

			_swayObjectGroup = Contexts.sharedInstance.gameplay.GetGroup(swayObjectMatcher);
		}
		
		public void Execute()
		{
			var rotateInput = Contexts.sharedInstance.app.inputCmp.rotateInput;
			var playerVelocity = Contexts.sharedInstance.gameplay.playerCmpEntity.velocityCmp.currentVelocity;

			foreach(var entity in _swayObjectGroup)
			{
				var swayTransformMdl = entity.transformMdl;
				var swayCmp = entity.swayCmp;
				var destinationLocalRotation = swayTransformMdl.initialLocalRotation * GetSwayDeltaRotationDueToInput(rotateInput, swayCmp);
				var destinationLocalPosition = swayTransformMdl.initialLocalPosition + GetSwayDeltaMovementDueToInput(playerVelocity, swayCmp);
				
				swayTransformMdl.transform.localRotation = Quaternion.Slerp
					(
						swayTransformMdl.transform.localRotation,
						destinationLocalRotation, 
						1f - Mathf.Pow(swayCmp.rotationDumping, Time.deltaTime)
					);

				swayTransformMdl.transform.localPosition = Vector3.Lerp
				(
					swayTransformMdl.transform.localPosition,
					destinationLocalPosition,
					1f - Mathf.Pow(swayCmp.movementDumping, Time.deltaTime)
				);
			}
		}

		private Quaternion GetSwayDeltaRotationDueToInput(in Vector2 inputDeltaRotation, SwayCmp swayCmp)
		{
			float xRotationOffset = Mathf.Clamp(inputDeltaRotation.y * swayCmp.rotationSwayForce, -3f, 3f);
			float yRotationOffset = Mathf.Clamp(-inputDeltaRotation.x * swayCmp.rotationSwayForce, -5f, 5f);
			float zRotationOffset = Mathf.Clamp(-inputDeltaRotation.x * swayCmp.rotationSwayForce, -10f, 10f);

			return Quaternion.AngleAxis(xRotationOffset, Vector3.right) *
			       Quaternion.AngleAxis(yRotationOffset, Vector3.up) *
			       Quaternion.AngleAxis(zRotationOffset, Vector3.forward);
		}

		private Vector3 GetSwayDeltaMovementDueToInput(Vector3 playerVelocity, SwayCmp swayCmp)
		{
			playerVelocity.y = 0f;
			
			var zMovementOffset = playerVelocity.sqrMagnitude > 1f ? -swayCmp.movementSwayForce : 0f;
			zMovementOffset = Mathf.Clamp(zMovementOffset, -.1f, .1f);

			return Vector3.forward * zMovementOffset;
		}
	}
}