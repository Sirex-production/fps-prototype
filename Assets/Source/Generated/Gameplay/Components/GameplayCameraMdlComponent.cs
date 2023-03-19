//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public EcsSupport.UnityIntegration.Models.CameraMdl cameraMdl { get { return (EcsSupport.UnityIntegration.Models.CameraMdl)GetComponent(GameplayComponentsLookup.CameraMdl); } }
    public bool hasCameraMdl { get { return HasComponent(GameplayComponentsLookup.CameraMdl); } }

    public void AddCameraMdl(UnityEngine.Camera newCamera) {
        var index = GameplayComponentsLookup.CameraMdl;
        var component = (EcsSupport.UnityIntegration.Models.CameraMdl)CreateComponent(index, typeof(EcsSupport.UnityIntegration.Models.CameraMdl));
        component.camera = newCamera;
        AddComponent(index, component);
    }

    public void ReplaceCameraMdl(UnityEngine.Camera newCamera) {
        var index = GameplayComponentsLookup.CameraMdl;
        var component = (EcsSupport.UnityIntegration.Models.CameraMdl)CreateComponent(index, typeof(EcsSupport.UnityIntegration.Models.CameraMdl));
        component.camera = newCamera;
        ReplaceComponent(index, component);
    }

    public void RemoveCameraMdl() {
        RemoveComponent(GameplayComponentsLookup.CameraMdl);
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

    static Entitas.IMatcher<GameplayEntity> _matcherCameraMdl;

    public static Entitas.IMatcher<GameplayEntity> CameraMdl {
        get {
            if (_matcherCameraMdl == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.CameraMdl);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherCameraMdl = matcher;
            }

            return _matcherCameraMdl;
        }
    }
}