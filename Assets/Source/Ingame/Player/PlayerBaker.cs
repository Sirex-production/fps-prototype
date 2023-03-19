using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Player
{
	public sealed class PlayerBaker : MonoBehaviour
	{
		[Required, SerializeField] private CharacterController characterController;

		[Inject]
		private void Construct()
		{
			var entity = Contexts.sharedInstance.gameplay.CreateEntity();
			
			entity.AddTransformMdl(transform);
			entity.AddCharacterControllerMdl(characterController);
			entity.AddVelocityCmp(Vector3.zero);
			entity.isPlayerCmp = true;
		}
	}
}