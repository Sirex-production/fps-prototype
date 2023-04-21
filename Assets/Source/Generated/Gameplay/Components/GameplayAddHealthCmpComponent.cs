//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public Ingame.Effects.AddHealthCmp addHealthCmp { get { return (Ingame.Effects.AddHealthCmp)GetComponent(GameplayComponentsLookup.AddHealthCmp); } }
    public bool hasAddHealthCmp { get { return HasComponent(GameplayComponentsLookup.AddHealthCmp); } }

    public void AddAddHealthCmp(float newAmountOfHealth) {
        var index = GameplayComponentsLookup.AddHealthCmp;
        var component = (Ingame.Effects.AddHealthCmp)CreateComponent(index, typeof(Ingame.Effects.AddHealthCmp));
        component.amountOfHealth = newAmountOfHealth;
        AddComponent(index, component);
    }

    public void ReplaceAddHealthCmp(float newAmountOfHealth) {
        var index = GameplayComponentsLookup.AddHealthCmp;
        var component = (Ingame.Effects.AddHealthCmp)CreateComponent(index, typeof(Ingame.Effects.AddHealthCmp));
        component.amountOfHealth = newAmountOfHealth;
        ReplaceComponent(index, component);
    }

    public void RemoveAddHealthCmp() {
        RemoveComponent(GameplayComponentsLookup.AddHealthCmp);
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

    static Entitas.IMatcher<GameplayEntity> _matcherAddHealthCmp;

    public static Entitas.IMatcher<GameplayEntity> AddHealthCmp {
        get {
            if (_matcherAddHealthCmp == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.AddHealthCmp);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherAddHealthCmp = matcher;
            }

            return _matcherAddHealthCmp;
        }
    }
}