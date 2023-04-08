using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Ingame.Input
{
	[App, Unique]
	public sealed class InputCmp : IComponent
	{
		//Movement
		public Vector2 moveInput;
		public Vector2 rotateInput;
		public bool jumpInput;
		public bool dashInput;

		//Combat
		public bool nextWeaponInput;
		public bool prevWeaponInput;
		public bool shootHoldInput;
		public bool shootTapInput;
	}
}