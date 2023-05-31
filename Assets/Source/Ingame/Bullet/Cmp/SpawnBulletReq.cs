using System;
using Entitas;
using UnityEngine;

namespace Ingame.Ai.Bullet.Cmp
{
    [Gameplay]
    public sealed class SpawnBulletReq : IComponent
    {
        public Type type;
        public Transform startingPosition;
        public Vector3 direction;
        public float force;
        public float damage;
    }
}