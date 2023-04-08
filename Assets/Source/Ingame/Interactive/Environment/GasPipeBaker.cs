using System;
using Entitas.Unity;
using Ingame.Ai.Cmp;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Ingame.Interactive.Environment
{
    public sealed class GasPipeBaker : MonoBehaviour
    {
        [SerializeField] 
        [Required] 
        private ParticleSystem _particleSystem;

        [SerializeField]
        [Min(0)] 
        private float durability = 5;
        
        [Inject]
        private void Construct()
        {
            var entity = Contexts.sharedInstance.gameplay.CreateEntity();
            
            entity.AddHealthCmp(durability);
            entity.hasInteractiveObjectTag = true;
            entity.hasGasPipeTag = true;
            entity.AddParticleEffectMdl(_particleSystem);

            gameObject.Link(entity);
        }

        private void OnDestroy()
        {
            gameObject.Unlink();
        }
    }
}