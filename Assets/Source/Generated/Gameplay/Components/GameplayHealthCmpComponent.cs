//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public Ingame.Effects.HealthCmp healthCmp { get { return (Ingame.Effects.HealthCmp)GetComponent(GameplayComponentsLookup.HealthCmp); } }
    public bool hasHealthCmp { get { return HasComponent(GameplayComponentsLookup.HealthCmp); } }

    public void AddHealthCmp(float newInitialHealth, float newCurrentHealth) {
        var index = GameplayComponentsLookup.HealthCmp;
        var component = (Ingame.Effects.HealthCmp)CreateComponent(index, typeof(Ingame.Effects.HealthCmp));
        component.initialHealth = newInitialHealth;
        component.currentHealth = newCurrentHealth;
        AddComponent(index, component);
    }

    public void ReplaceHealthCmp(float newInitialHealth, float newCurrentHealth) {
        var index = GameplayComponentsLookup.HealthCmp;
        var component = (Ingame.Effects.HealthCmp)CreateComponent(index, typeof(Ingame.Effects.HealthCmp));
        component.initialHealth = newInitialHealth;
        component.currentHealth = newCurrentHealth;
        ReplaceComponent(index, component);
    }

    public void RemoveHealthCmp() {
        RemoveComponent(GameplayComponentsLookup.HealthCmp);
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

    static Entitas.IMatcher<GameplayEntity> _matcherHealthCmp;

    public static Entitas.IMatcher<GameplayEntity> HealthCmp {
        get {
            if (_matcherHealthCmp == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.HealthCmp);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherHealthCmp = matcher;
            }

            return _matcherHealthCmp;
        }
    }
}
