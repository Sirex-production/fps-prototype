//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayContext {

    public GameplayEntity mainVirtualCameraTagEntity { get { return GetGroup(GameplayMatcher.MainVirtualCameraTag).GetSingleEntity(); } }

    public bool hasMainVirtualCameraTag {
        get { return mainVirtualCameraTagEntity != null; }
        set {
            var entity = mainVirtualCameraTagEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().hasMainVirtualCameraTag = true;
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

    static readonly Ingame.Camerawork.MainVirtualCameraTag mainVirtualCameraTagComponent = new Ingame.Camerawork.MainVirtualCameraTag();

    public bool hasMainVirtualCameraTag {
        get { return HasComponent(GameplayComponentsLookup.MainVirtualCameraTag); }
        set {
            if (value != hasMainVirtualCameraTag) {
                var index = GameplayComponentsLookup.MainVirtualCameraTag;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : mainVirtualCameraTagComponent;

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

    static Entitas.IMatcher<GameplayEntity> _matcherMainVirtualCameraTag;

    public static Entitas.IMatcher<GameplayEntity> MainVirtualCameraTag {
        get {
            if (_matcherMainVirtualCameraTag == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.MainVirtualCameraTag);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherMainVirtualCameraTag = matcher;
            }

            return _matcherMainVirtualCameraTag;
        }
    }
}