using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Player.Abilities.Hook
{
	public sealed class HookBaker : MonoBehaviour
	{
		[BoxGroup("HookCmp")] [SerializeField] [Min(0f)]
		private float cooldown;

		[BoxGroup("HookCmp")] [SerializeField] [Min(0f)]
		private float speed;

		[BoxGroup("HookCmp")] [SerializeField] [Range(0f, 90f)]
		private float targetDetectionAngle;

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			entity.AddHookCmp(cooldown, speed, targetDetectionAngle, 0f, 0f);
			entity.AddTransformMdl(transform, transform.localRotation, transform.localPosition);
		}
	}
}