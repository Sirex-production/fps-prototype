using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Ingame.Camerawork.Recoil
{
	[Gameplay, Unique]
	public sealed class HudRecoilCmp : IComponent
	{
		public Vector2 currentRecoilOffset;
	}
}