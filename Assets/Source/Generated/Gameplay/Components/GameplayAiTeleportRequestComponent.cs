//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    static readonly Source.Ingame.AiSupport.Cmp.AiTeleportRequest aiTeleportRequestComponent = new Source.Ingame.AiSupport.Cmp.AiTeleportRequest();

    public bool hasAiTeleportRequest {
        get { return HasComponent(GameplayComponentsLookup.AiTeleportRequest); }
        set {
            if (value != hasAiTeleportRequest) {
                var index = GameplayComponentsLookup.AiTeleportRequest;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : aiTeleportRequestComponent;

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

    static Entitas.IMatcher<GameplayEntity> _matcherAiTeleportRequest;

    public static Entitas.IMatcher<GameplayEntity> AiTeleportRequest {
        get {
            if (_matcherAiTeleportRequest == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.AiTeleportRequest);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherAiTeleportRequest = matcher;
            }

            return _matcherAiTeleportRequest;
        }
    }
}
