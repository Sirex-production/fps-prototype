using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Vfx.ShotTrail.FloatingEffect
{
	public sealed class FloatingItemBaker : MonoBehaviour
	{
		[BoxGroup("FloatingItemEffectCmp")]
		[SerializeField] private AnimationCurve  floatingCurve;
		[BoxGroup("FloatingItemEffectCmp")]
		[SerializeField] [Min(0f)] private float speed;
		[BoxGroup("FloatingItemEffectCmp")]
		[SerializeField] [Min(0f)] private float strength;
		[BoxGroup("FloatingItemEffectCmp")]
		[SerializeField] [Min(0f)] private float rotationSpeed;

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			entity.AddFloatingItemEffectCmp(floatingCurve, speed, strength, rotationSpeed, 0f);
			entity.AddTransformMdl(transform, transform.localRotation, transform.localPosition);
		}
	}
}