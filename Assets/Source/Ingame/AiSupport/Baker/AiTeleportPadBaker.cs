using System;
using Entitas.Unity;
using UnityEngine;
using Zenject;

namespace Source.Ingame.AiSupport.Baker
{
    public sealed class AiTeleportPadBaker : MonoBehaviour
    {
        private GameplayEntity _entity;
        
        [Inject]
        private void Construct()
        {
            _entity = Contexts.sharedInstance.gameplay.CreateEntity();
            _entity.AddTransformMdl(transform, transform.localRotation, transform.localPosition);
            _entity.hasAiTeleportPadTag = true;
        }
 
    }
}