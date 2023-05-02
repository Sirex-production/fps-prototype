using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Ingame.Ai.Cmp
{
    [Gameplay]
    public sealed class FlyingAiCmp : IComponent
    {
        public Vector3 lastPosition;
    }
}