//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameplayEventSystems : Feature {

    public GameplayEventSystems(Contexts contexts) {
        Add(new OnCollisionEnterEventEventSystem(contexts)); // priority: 0
        Add(new OnCollisionExitEventEventSystem(contexts)); // priority: 0
        Add(new OnCollisionStayEventEventSystem(contexts)); // priority: 0
        Add(new OnTriggerEnterEventEventSystem(contexts)); // priority: 0
        Add(new OnTriggerExitEventEventSystem(contexts)); // priority: 0
        Add(new OnTriggerStayEventEventSystem(contexts)); // priority: 0
        Add(new PerformMeleeAttackReqEventSystem(contexts)); // priority: 0
        Add(new WeaponSwitchEventEventSystem(contexts)); // priority: 0
    }
}
