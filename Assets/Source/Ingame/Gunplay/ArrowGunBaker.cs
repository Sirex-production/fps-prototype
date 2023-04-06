using System;
using EcsSupport.UnityIntegration;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Gunplay
{
	public sealed class ArrowGunBaker : MonoBehaviour
	{
		[BoxGroup("Entity reference")]
		[Required, SerializeField] [Min(0f)] private GameplayEntityReference gameplayEntityReference;
		
		[BoxGroup("SwayCmp")]
		[SerializeField] private AnimationCurve bobbingAnimationCurve;
		[BoxGroup("SwayCmp")]
		[SerializeField] [Min(0f)] private float rotationDumping = .0001f;
		[BoxGroup("SwayCmp")]
		[SerializeField] [Min(0f)] private float movementDumping = .0001f;
		[BoxGroup("SwayCmp")]
		[SerializeField] [Min(0f)] private float rotationSwayForce = 1f;
		[BoxGroup("SwayCmp")]
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

		[BoxGroup("ArrowSpawnerCmp")]
		[Required, SerializeField] private Transform spawnOriginTransform;
		[BoxGroup("ArrowSpawnerCmp")]
		[Required, SerializeField] private ArrowProjectileBaker arrowProjectilePrefab;
		[BoxGroup("ArrowSpawnerCmp")]
		[SerializeField] private float pauseBetweenShots;

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();

			gameplayEntityReference.attachedEntity = entity;

			entity.AddSwayCmp
			(
				bobbingAnimationCurve,
				rotationDumping,
				movementDumping,
				rotationSwayForce,
				movementSwayForce
			);
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
			entity.AddArrowSpawnerCmp(spawnOriginTransform, arrowProjectilePrefab, 0f, pauseBetweenShots);
			entity.AddTransformMdl(transform, transform.localRotation, transform.localPosition);
		}
	}
}