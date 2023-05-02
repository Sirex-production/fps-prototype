using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Source.EcsSupport.Support
{
    [Gameplay]
    public sealed class ClearLinkOnDestroyMdl : IComponent
    {
        public GameObject linkedGameObject;
    }
}