//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    static readonly Ingame.Player.Movement.IsRotationLockedTag isRotationLockedTagComponent = new Ingame.Player.Movement.IsRotationLockedTag();

    public bool hasIsRotationLockedTag {
        get { return HasComponent(GameplayComponentsLookup.IsRotationLockedTag); }
        set {
            if (value != hasIsRotationLockedTag) {
                var index = GameplayComponentsLookup.IsRotationLockedTag;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : isRotationLockedTagComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameplayEntity> _matcherIsRotationLockedTag;

    public static Entitas.IMatcher<GameplayEntity> IsRotationLockedTag {
        get {
            if (_matcherIsRotationLockedTag == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.IsRotationLockedTag);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherIsRotationLockedTag = matcher;
            }

            return _matcherIsRotationLockedTag;
        }
    }
}