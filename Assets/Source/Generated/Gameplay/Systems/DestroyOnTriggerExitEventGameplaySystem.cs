//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.Roslyn.CodeGeneration.Plugins.CleanupSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections.Generic;
using Entitas;

public sealed class DestroyOnTriggerExitEventGameplaySystem : ICleanupSystem {

    readonly IGroup<GameplayEntity> _group;
    readonly List<GameplayEntity> _buffer = new List<GameplayEntity>();

    public DestroyOnTriggerExitEventGameplaySystem(Contexts contexts) {
        _group = contexts.gameplay.GetGroup(GameplayMatcher.OnTriggerExitEvent);
    }

    public void Cleanup() {
        foreach (var e in _group.GetEntities(_buffer)) {
            e.Destroy();
        }
    }
}
