using EcsSupport.UnityIntegration;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Gunplay.Axe
{
	public sealed class AxeBaker : MonoBehaviour
	{
		[BoxGroup("Entity reference")]
		[Required, SerializeField] [Min(0f)] private GameplayEntityReference gameplayEntityReference;
		
		[BoxGroup("AnimatorMdl")]
		[Required, SerializeField] private Animator animator;
		
		[BoxGroup("AxeCmp")]
		[SerializeField] [Min(0f)] private float range = 1f;
		[BoxGroup("AxeCmp")]
		[SerializeField] [Min(0f)] private float damage = 80f;
		
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

			entity.AddAxeCmp(range, damage);
			entity.AddSwayCmp(bobbingAnimationCurve,rotationDumping, movementDumping, rotationSwayForce, movementSwayForce);
			entity.AddAnimatorMdl(animator);
			entity.AddTransformMdl(transform, transform.localRotation, transform.localPosition);
		}
	}
}