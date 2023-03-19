//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayContext {

    public GameplayEntity playerCmpEntity { get { return GetGroup(GameplayMatcher.PlayerCmp).GetSingleEntity(); } }

    public bool isPlayerCmp {
        get { return playerCmpEntity != null; }
        set {
            var entity = playerCmpEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isPlayerCmp = true;
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

    static readonly Ingame.Player.Common.PlayerCmp playerCmpComponent = new Ingame.Player.Common.PlayerCmp();

    public bool isPlayerCmp {
        get { return HasComponent(GameplayComponentsLookup.PlayerCmp); }
        set {
            if (value != isPlayerCmp) {
                var index = GameplayComponentsLookup.PlayerCmp;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : playerCmpComponent;

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

    static Entitas.IMatcher<GameplayEntity> _matcherPlayerCmp;

    public static Entitas.IMatcher<GameplayEntity> PlayerCmp {
        get {
            if (_matcherPlayerCmp == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.PlayerCmp);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherPlayerCmp = matcher;
            }

            return _matcherPlayerCmp;
        }
    }
}
