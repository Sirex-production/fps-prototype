using Entitas;
using UnityEngine;

namespace Ingame.Gunplay.Sway
{
	public sealed class RotateWeaponDueToRecoilSystem : IExecuteSystem
	{
		private readonly IGroup<GameplayEntity> _recoilGroup;

		public RotateWeaponDueToRecoilSystem()
		{
			var recoilMatcher = GameplayMatcher.AllOf
			(
				GameplayMatcher.TransformMdl,
				GameplayMatcher.RecoilCmp,
				GameplayMatcher.InHangsTag
			);

			_recoilGroup = Contexts.sharedInstance.gameplay.GetGroup(recoilMatcher);
		}
		
		public void Execute()
		{
			foreach(var entity in _recoilGroup)
			{
				var transformMdl = entity.transformMdl;
				var recoilCmp = entity.recoilCmp;
				var targetLocalRotation = transformMdl.initialLocalRotation * Quaternion.Euler(recoilCmp.CurrentDeltaRotation);
				
				transformMdl.transform.localRotation = Quaternion.Slerp
				(
					transformMdl.transform.localRotation,
					targetLocalRotation,
					1f - Mathf.Pow(recoilCmp.positionDumping, Time.deltaTime)
				);
				
				if(Contexts.sharedInstance.gameplay.hasShotPerformedEvent)
				{
					recoilCmp.currentRecoil = Mathf.Clamp01(recoilCmp.currentRecoil + recoilCmp.recoilGain);
					return;
				}

				recoilCmp.currentRecoil = Mathf.Lerp
				(
					recoilCmp.currentRecoil,
					0f,
					1f - Mathf.Pow(recoilCmp.recoilStabilizationDumping, Time.deltaTime)
				);
			}
		}
	}
}