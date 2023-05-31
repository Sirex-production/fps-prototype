using System;
using EcsSupport.UnityIntegration;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Ingame.Bullet
{
    [RequireComponent(typeof(GameplayEntityReference))]
    public sealed class BulletBaker : MonoBehaviour
    {
        [FormerlySerializedAs("bullet")] [Required] [SerializeField] private BulletBasic bulletBasic;
        [Required] [SerializeField] private GameplayEntityReference gameplayEntityReference;

        [Inject]
        private void Construct()
        {
            var entity = Contexts.sharedInstance.gameplay.CreateEntity();
            gameplayEntityReference.attachedEntity = entity;
            
            entity.AddBulletMdl(bulletBasic);
            entity.AddTransformMdl(transform, Quaternion.identity, Vector3.zero);
            entity.AddForcePowerCmp(0f);
            entity.AddDirectionCmp(Vector3.zero);
        }

        private void Awake()
        {
            Destroy(this);
        }
    }
}