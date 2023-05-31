using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Player.Abilities.Hook
{
	public sealed class HookTargetBaker : MonoBehaviour
	{
		[BoxGroup("HookTargetCmp")]
		[SerializeField] private HookTargetCmp.HookType hookType;

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			entity.AddHookTargetCmp(hookType);
			entity.AddTransformMdl(transform, transform.localRotation, transform.localPosition);
		}
	}
}