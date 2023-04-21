//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public Ingame.Player.Movement.DashingCmp dashingCmp { get { return (Ingame.Player.Movement.DashingCmp)GetComponent(GameplayComponentsLookup.DashingCmp); } }
    public bool hasDashingCmp { get { return HasComponent(GameplayComponentsLookup.DashingCmp); } }

    public void AddDashingCmp(UnityEngine.Vector3 newDashingVelocity, float newCurrentDashDuration, float newTimePassedSinceLastDash) {
        var index = GameplayComponentsLookup.DashingCmp;
        var component = (Ingame.Player.Movement.DashingCmp)CreateComponent(index, typeof(Ingame.Player.Movement.DashingCmp));
        component.dashingVelocity = newDashingVelocity;
        component.currentDashDuration = newCurrentDashDuration;
        component.timePassedSinceLastDash = newTimePassedSinceLastDash;
        AddComponent(index, component);
    }

    public void ReplaceDashingCmp(UnityEngine.Vector3 newDashingVelocity, float newCurrentDashDuration, float newTimePassedSinceLastDash) {
        var index = GameplayComponentsLookup.DashingCmp;
        var component = (Ingame.Player.Movement.DashingCmp)CreateComponent(index, typeof(Ingame.Player.Movement.DashingCmp));
        component.dashingVelocity = newDashingVelocity;
        component.currentDashDuration = newCurrentDashDuration;
        component.timePassedSinceLastDash = newTimePassedSinceLastDash;
        ReplaceComponent(index, component);
    }

    public void RemoveDashingCmp() {
        RemoveComponent(GameplayComponentsLookup.DashingCmp);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameplayMatcher {

    static Entitas.IMatcher<GameplayEntity> _matcherDashingCmp;

    public static Entitas.IMatcher<GameplayEntity> DashingCmp {
        get {
            if (_matcherDashingCmp == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.DashingCmp);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherDashingCmp = matcher;
            }

            return _matcherDashingCmp;
        }
    }
}