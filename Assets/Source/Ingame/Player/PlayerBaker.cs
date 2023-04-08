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

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			entity.AddTransformMdl(transform, transform.localRotation, transform.position);
			entity.AddDashingCmp(Vector3.zero, 0f, 0f);
			entity.AddCharacterControllerMdl(characterController);
			entity.AddVelocityCmp(Vector3.zero, 0f);
			entity.AddGroundCheckCmp(raycastOrigin, distance, sphereCastRadius);
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