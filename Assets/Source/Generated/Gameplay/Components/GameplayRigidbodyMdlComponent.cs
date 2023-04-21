//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public EcsSupport.UnityIntegration.Models.RigidbodyMdl rigidbodyMdl { get { return (EcsSupport.UnityIntegration.Models.RigidbodyMdl)GetComponent(GameplayComponentsLookup.RigidbodyMdl); } }
    public bool hasRigidbodyMdl { get { return HasComponent(GameplayComponentsLookup.RigidbodyMdl); } }

    public void AddRigidbodyMdl(UnityEngine.Rigidbody newRigidbody) {
        var index = GameplayComponentsLookup.RigidbodyMdl;
        var component = (EcsSupport.UnityIntegration.Models.RigidbodyMdl)CreateComponent(index, typeof(EcsSupport.UnityIntegration.Models.RigidbodyMdl));
        component.rigidbody = newRigidbody;
        AddComponent(index, component);
    }

    public void ReplaceRigidbodyMdl(UnityEngine.Rigidbody newRigidbody) {
        var index = GameplayComponentsLookup.RigidbodyMdl;
        var component = (EcsSupport.UnityIntegration.Models.RigidbodyMdl)CreateComponent(index, typeof(EcsSupport.UnityIntegration.Models.RigidbodyMdl));
        component.rigidbody = newRigidbody;
        ReplaceComponent(index, component);
    }

    public void RemoveRigidbodyMdl() {
        RemoveComponent(GameplayComponentsLookup.RigidbodyMdl);
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

    static Entitas.IMatcher<GameplayEntity> _matcherRigidbodyMdl;

    public static Entitas.IMatcher<GameplayEntity> RigidbodyMdl {
        get {
            if (_matcherRigidbodyMdl == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.RigidbodyMdl);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherRigidbodyMdl = matcher;
            }

            return _matcherRigidbodyMdl;
        }
    }
}