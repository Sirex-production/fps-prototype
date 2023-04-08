using EcsSupport.UnityIntegration;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Gunplay.Sway
{
	public class WeaponBaker : MonoBehaviour
	{
		[BoxGroup("Entity reference")]
		[Required, SerializeField] [Min(0f)] private GameplayEntityReference gameplayEntityReference;
		
		[BoxGroup("Sway")]
		[SerializeField] private AnimationCurve bobbingAnimationCurve;
		[BoxGroup("Sway")]
		[SerializeField] [Min(0f)] private float rotationDumping = .0001f;
		[BoxGroup("Sway")]
		[SerializeField] [Min(0f)] private float movementDumping = .0001f;
		[BoxGroup("Sway")]
		[SerializeField] [Min(0f)] private float rotationSwayForce = 1f;
		[BoxGroup("Sway")]
		[SerializeField] [Min(0f)] private float movementSwayForce = .5f;
		
		[BoxGroup("RecoilCmp")]
		[SerializeField] private AnimationCurve recoilCurveX;
		[BoxGroup("RecoilCmp")]
		[SerializeField] private AnimationCurve recoilCurveY;
		[BoxGroup("RecoilCmp")]
		[SerializeField] private AnimationCurve recoilCurveZ;
		[BoxGroup("RecoilCmp")]
		[SerializeField] [Range(0, 1f)] private float positionDumping;
		[BoxGroup("RecoilCmp")]
		[SerializeField] [Range(0, 1f)] private float recoilStabilizationDumping;
		[BoxGroup("RecoilCmp")]
		[SerializeField] [Range(0, 1f)] private float recoilGain;
		[BoxGroup("RecoilCmp")]
		[SerializeField] [Min(0f)] private float recoilStrength;

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			BakeWeapon(entity);
		}

		protected void BakeWeapon(GameplayEntity entity)
		{
			gameplayEntityReference.attachedEntity = entity;
			
			entity.AddTransformMdl(transform, transform.localRotation, transform.localPosition);
			entity.AddSwayCmp(bobbingAnimationCurve,rotationDumping, movementDumping, rotationSwayForce, movementSwayForce);
			entity.AddRecoilCmp
			(
				recoilCurveX,
				recoilCurveY,
				recoilCurveZ,
				positionDumping,
				recoilStabilizationDumping,
				recoilGain,
				recoilStrength,
				0f
			);
		}
	}
}