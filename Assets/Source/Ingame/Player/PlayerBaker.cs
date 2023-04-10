using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Player
{
	public sealed class PlayerBaker : MonoBehaviour
	{
		[BoxGroup("CharacterControllerMdl")]
		[Required, SerializeField] private CharacterController characterController;
		
		[BoxGroup("GroundCheckCmp")]
		[Required, SerializeField] private Transform raycastOrigin;
		[BoxGroup("GroundCheckCmp")]
		[SerializeField] [Min(0f)] private float distance;
		[BoxGroup("GroundCheckCmp")]
		[SerializeField] [Min(0f)] private float sphereCastRadius;
		
		[BoxGroup("HealthCmp")]
		[SerializeField] [Min(0f)] private float currentHealth = 100f;
		[BoxGroup("HealthCmp")]
		[SerializeField] [Min(0f)] private float maxHealth = 100f;
		
		[BoxGroup("ArmorCmp")]
		[SerializeField] [Range(0f, 1f)] private float percentageOfDamageBlockedByArmor = .25f;
		[BoxGroup("ArmorCmp")]
		[SerializeField] [Range(0f, 1f)] private float percentageOfArmorTaken = .25f;
		[BoxGroup("ArmorCmp")]
		[SerializeField] [Min(0f)] private float maximumArmor = 100f;
		[BoxGroup("ArmorCmp")]
		[SerializeField] [Min(0f)] private float currentArmor = 100f;

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			entity.AddTransformMdl(transform, transform.localRotation, transform.position);
			entity.AddDashingCmp(Vector3.zero, 0f, 0f);
			entity.AddSlidingCmp(Vector3.zero, 999f, 0f);
			entity.AddCharacterControllerMdl(characterController);
			entity.AddVelocityCmp(Vector3.zero, 0f);
			entity.AddGroundCheckCmp(raycastOrigin, distance, sphereCastRadius, false);
			entity.AddHealthCmp(maxHealth, currentHealth);
			entity.AddArmorCmp(percentageOfDamageBlockedByArmor, percentageOfArmorTaken, maximumArmor, currentArmor);
			entity.hasPlayerCmp = true;
		}

		private void OnDrawGizmos()
		{
			if(raycastOrigin == null)
				return;

			var originPos = raycastOrigin.position;
			var spherePos = raycastOrigin.position + raycastOrigin.forward * distance;
			
			Gizmos.color = Color.blue;

			Gizmos.DrawLine(originPos, spherePos);
			Gizmos.DrawWireSphere(spherePos, sphereCastRadius);
		}
	}
}