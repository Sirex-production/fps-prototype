using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Gunplay.MeleeAttack
{
	public sealed class MeleeRangeBaker : MonoBehaviour
	{
		[BoxGroup("Gizmos preview (does not impact any components)")]
		[SerializeField] private float range = 1f;

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			entity.AddTransformMdl(transform, transform.localRotation, transform.localPosition);
			entity.hasMeleeAttackOriginTag = true;
		}
		
		private void OnDrawGizmos()
		{
			var sphereCenter = transform.position + transform.forward * range;
			
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(sphereCenter, range);
		}
	}
}