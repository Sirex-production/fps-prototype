using EcsSupport.UnityIntegration;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Gunplay.Sway
{
	public sealed class WeaponHolderBaker : MonoBehaviour
	{
		[BoxGroup("AnimatorMdl")] 
		[Required, SerializeField] private Animator attachedAnimator;
		
		[BoxGroup("WeaponHolderCmp")]
		[SerializeField] private GameplayEntityReference[] weaponsEntities;

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			entity.AddAnimatorMdl(attachedAnimator);
			
			entity.AddWeaponHolderCmp(weaponsEntities, 0);
			entity.AddTransformMdl(transform, transform.localRotation, transform.localPosition);
		}
	}
}