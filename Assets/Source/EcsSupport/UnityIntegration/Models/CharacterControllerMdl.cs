using Entitas;
using UnityEngine;

namespace EcsSupport.UnityIntegration.Models
{
	[Gameplay]
	public sealed class CharacterControllerMdl : IComponent
	{
		public CharacterController characterController;
	}
}