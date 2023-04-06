//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public Ingame.Gunplay.ArrowGun.ArrowCmp arrowCmp { get { return (Ingame.Gunplay.ArrowGun.ArrowCmp)GetComponent(GameplayComponentsLookup.ArrowCmp); } }
    public bool hasArrowCmp { get { return HasComponent(GameplayComponentsLookup.ArrowCmp); } }

    public void AddArrowCmp(float newDamage) {
        var index = GameplayComponentsLookup.ArrowCmp;
        var component = (Ingame.Gunplay.ArrowGun.ArrowCmp)CreateComponent(index, typeof(Ingame.Gunplay.ArrowGun.ArrowCmp));
        component.damage = newDamage;
        AddComponent(index, component);
    }

    public void ReplaceArrowCmp(float newDamage) {
        var index = GameplayComponentsLookup.ArrowCmp;
        var component = (Ingame.Gunplay.ArrowGun.ArrowCmp)CreateComponent(index, typeof(Ingame.Gunplay.ArrowGun.ArrowCmp));
        component.damage = newDamage;
        ReplaceComponent(index, component);
    }

    public void RemoveArrowCmp() {
        RemoveComponent(GameplayComponentsLookup.ArrowCmp);
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

    static Entitas.IMatcher<GameplayEntity> _matcherArrowCmp;

    public static Entitas.IMatcher<GameplayEntity> ArrowCmp {
        get {
            if (_matcherArrowCmp == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.ArrowCmp);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherArrowCmp = matcher;
            }

            return _matcherArrowCmp;
        }
    }
}
