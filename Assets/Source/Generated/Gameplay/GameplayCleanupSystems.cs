//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.Roslyn.CodeGeneration.Plugins.CleanupSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameplayCleanupSystems : Feature {

    public GameplayCleanupSystems(Contexts contexts) {
        Add(new DestroyWeaponSwitchEventGameplaySystem(contexts));
        Add(new DestroyShotPerformedEventGameplaySystem(contexts));
        Add(new DestroyOnTriggerEnterEventGameplaySystem(contexts));
        Add(new DestroyOnTriggerStayEventGameplaySystem(contexts));
        Add(new DestroyOnTriggerExitEventGameplaySystem(contexts));
        Add(new DestroyOnCollisionEnterEventGameplaySystem(contexts));
        Add(new DestroyOnCollisionStayEventGameplaySystem(contexts));
        Add(new DestroyOnCollisionExitEventGameplaySystem(contexts));
    }
}