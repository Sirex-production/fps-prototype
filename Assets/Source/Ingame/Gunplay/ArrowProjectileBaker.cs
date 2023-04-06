using EcsSupport.UnityIntegration;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Gunplay
{
	public sealed class ArrowProjectileBaker : MonoBehaviour
	{
		[BoxGroup("Entity reference")]
		[Required, SerializeField] [Min(0f)] private GameplayEntityReference gameplayEntityReference;
		
		[BoxGroup("ArrowCmp")]
		[SerializeField] [Min(0f)] private float damage;

		[BoxGroup("ProjectileCmp")]
		[SerializeField] [Min(0f)] private float speed;

		public GameplayEntityReference GameplayEntityReference => gameplayEntityReference;
		
		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();

			gameplayEntityReference.attachedEntity = entity;
			
			entity.AddArrowCmp(damage);
			entity.AddProjectileCmp(speed);
			entity.AddTransformMdl(transform, transform.localRotation, transform.localPosition);
		}
	}
}