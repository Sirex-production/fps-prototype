
using Entitas;
using UnityEngine;

namespace EcsSupport.UnityIntegration.Models
{
    [Gameplay]
    public sealed class ParticleEffectMdl : IComponent
    {
        public ParticleSystem effect;
    }
}