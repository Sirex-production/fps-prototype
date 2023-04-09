using UnityEngine;
using Zenject;

namespace Ingame.Player.Movement
{
	public sealed class HudOriginBaker : MonoBehaviour
	{
		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();

			entity.AddHudOriginCmp(0f);
			entity.AddTransformMdl(transform, transform.localRotation, transform.position);
		}
	}
}