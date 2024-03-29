//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public Ingame.Effects.ArmorCmp armorCmp { get { return (Ingame.Effects.ArmorCmp)GetComponent(GameplayComponentsLookup.ArmorCmp); } }
    public bool hasArmorCmp { get { return HasComponent(GameplayComponentsLookup.ArmorCmp); } }

    public void AddArmorCmp(float newPercentageOfDamageBlockedByArmor, float newPercentageOfArmorTaken, float newMaximumArmor, float newCurrentArmor) {
        var index = GameplayComponentsLookup.ArmorCmp;
        var component = (Ingame.Effects.ArmorCmp)CreateComponent(index, typeof(Ingame.Effects.ArmorCmp));
        component.percentageOfDamageBlockedByArmor = newPercentageOfDamageBlockedByArmor;
        component.percentageOfArmorTaken = newPercentageOfArmorTaken;
        component.maximumArmor = newMaximumArmor;
        component.currentArmor = newCurrentArmor;
        AddComponent(index, component);
    }

    public void ReplaceArmorCmp(float newPercentageOfDamageBlockedByArmor, float newPercentageOfArmorTaken, float newMaximumArmor, float newCurrentArmor) {
        var index = GameplayComponentsLookup.ArmorCmp;
        var component = (Ingame.Effects.ArmorCmp)CreateComponent(index, typeof(Ingame.Effects.ArmorCmp));
        component.percentageOfDamageBlockedByArmor = newPercentageOfDamageBlockedByArmor;
        component.percentageOfArmorTaken = newPercentageOfArmorTaken;
        component.maximumArmor = newMaximumArmor;
        component.currentArmor = newCurrentArmor;
        ReplaceComponent(index, component);
    }

    public void RemoveArmorCmp() {
        RemoveComponent(GameplayComponentsLookup.ArmorCmp);
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

    static Entitas.IMatcher<GameplayEntity> _matcherArmorCmp;

    public static Entitas.IMatcher<GameplayEntity> ArmorCmp {
        get {
            if (_matcherArmorCmp == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.ArmorCmp);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherArmorCmp = matcher;
            }

            return _matcherArmorCmp;
        }
    }
}
