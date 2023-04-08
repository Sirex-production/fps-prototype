using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Player.DI
{
    public sealed class PlayerInstaller : MonoInstaller
    {
        [SerializeField] 
        [Required]
        private Transform playerTransform;

        public override void InstallBindings()
        {
            Container.Bind<Transform>()
                .WithId("Player")
                .FromInstance(playerTransform)
                .AsSingle()
                .NonLazy();
        }
    }
}