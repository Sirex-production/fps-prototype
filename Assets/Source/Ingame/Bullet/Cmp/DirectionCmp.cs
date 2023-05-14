using Entitas;
using UnityEngine;

namespace Ingame.Ai.Bullet.Cmp
{
    [Gameplay]
    public sealed class DirectionCmp : IComponent
    {
        public Vector3 direction;
    }
}