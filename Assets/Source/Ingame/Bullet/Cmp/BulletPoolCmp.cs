using System;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine.Pool;

namespace Ingame.Ai.Bullet.Cmp
{
    [Gameplay, Unique]
    public sealed class BulletPoolCmp : IComponent
    {
        public Dictionary<Type, IObjectPool<GameplayEntity>> pools;
    }
}