using System;
using System.Collections.Generic;
using Entitas;
using Ingame.Bullet;

namespace Ingame.Ai.Bullet.Cmp
{
    [Gameplay]
    public sealed class BulletTypesMdl : IComponent
    {
        public Dictionary<Type,BulletBasic> bulletsTypes;
    }
}