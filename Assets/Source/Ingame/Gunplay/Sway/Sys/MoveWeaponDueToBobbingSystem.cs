using Entitas;
using UnityEngine;

namespace Ingame.Gunplay.Sway
{
	public sealed class MoveWeaponDueToBobbingSystem : IExecuteSystem
	{
		private readonly IGroup<GameplayEntity> _swayObjectGroup;

		public MoveWeaponDueToBobbingSystem()
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
			var playerEntity = Contexts.sharedInstance.gameplay.playerCmpEntity;
			
			if(!playerEntity.hasVelocityCmp || !playerEntity.hasGroundCheckCmp)
				return;
			
			var playerTravelTime = playerEntity.velocityCmp.timeSpentTraveling;
			bool isGrounded = playerEntity.groundCheckCmp.IsGrounded();
			
			if(!isGrounded)
				return;

			foreach(var entity in _swayObjectGroup)
			{
				var transformMdl = entity.transformMdl;
				var swayCmp = entity.swayCmp;
				var targetLocalPosition = transformMdl.initialLocalPosition + GetBobbingOffset(playerTravelTime, swayCmp);
				
				transformMdl.transform.localPosition = Vector3.Lerp
				(
					transformMdl.transform.localPosition,
					targetLocalPosition,
					1f - Mathf.Pow(swayCmp.movementDumping, Time.deltaTime)
				);
			}
		}

		private Vector3 GetBobbingOffset(in float travelTime, SwayCmp swayCmp)
		{
			float sinTravel = Mathf.Abs(Mathf.Cos(travelTime * 8f));

			float yOffset = swayCmp.bobbingCurveY.Evaluate(sinTravel) * .1f;

			return Vector3.up * yOffset;
		}
	}
}