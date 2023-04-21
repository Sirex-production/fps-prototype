//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayContext {

    public GameplayEntity isMagnetActiveTagEntity { get { return GetGroup(GameplayMatcher.IsMagnetActiveTag).GetSingleEntity(); } }

    public bool hasIsMagnetActiveTag {
        get { return isMagnetActiveTagEntity != null; }
        set {
            var entity = isMagnetActiveTagEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().hasIsMagnetActiveTag = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    static readonly Ingame.Player.Abilities.Magnet.IsMagnetActiveTag isMagnetActiveTagComponent = new Ingame.Player.Abilities.Magnet.IsMagnetActiveTag();

    public bool hasIsMagnetActiveTag {
        get { return HasComponent(GameplayComponentsLookup.IsMagnetActiveTag); }
        set {
            if (value != hasIsMagnetActiveTag) {
                var index = GameplayComponentsLookup.IsMagnetActiveTag;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : isMagnetActiveTagComponent;

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

    static Entitas.IMatcher<GameplayEntity> _matcherIsMagnetActiveTag;

    public static Entitas.IMatcher<GameplayEntity> IsMagnetActiveTag {
        get {
            if (_matcherIsMagnetActiveTag == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.IsMagnetActiveTag);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherIsMagnetActiveTag = matcher;
            }

            return _matcherIsMagnetActiveTag;
        }
    }
}
