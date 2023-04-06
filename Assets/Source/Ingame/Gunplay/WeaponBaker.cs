using EcsSupport.UnityIntegration;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Gunplay.Sway
{
	public sealed class WeaponBaker : MonoBehaviour
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

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			gameplayEntityReference.attachedEntity = entity;
			
			entity.AddTransformMdl(transform, transform.localRotation, transform.localPosition);
			entity.AddSwayCmp(bobbingAnimationCurve,rotationDumping, movementDumping, rotationSwayForce, movementSwayForce);
		}
	}
}