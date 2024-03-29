//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public EcsSupport.UnityIntegration.Models.TransformMdl transformMdl { get { return (EcsSupport.UnityIntegration.Models.TransformMdl)GetComponent(GameplayComponentsLookup.TransformMdl); } }
    public bool hasTransformMdl { get { return HasComponent(GameplayComponentsLookup.TransformMdl); } }

    public void AddTransformMdl(UnityEngine.Transform newTransform, UnityEngine.Quaternion newInitialLocalRotation, UnityEngine.Vector3 newInitialLocalPosition) {
        var index = GameplayComponentsLookup.TransformMdl;
        var component = (EcsSupport.UnityIntegration.Models.TransformMdl)CreateComponent(index, typeof(EcsSupport.UnityIntegration.Models.TransformMdl));
        component.transform = newTransform;
        component.initialLocalRotation = newInitialLocalRotation;
        component.initialLocalPosition = newInitialLocalPosition;
        AddComponent(index, component);
    }

    public void ReplaceTransformMdl(UnityEngine.Transform newTransform, UnityEngine.Quaternion newInitialLocalRotation, UnityEngine.Vector3 newInitialLocalPosition) {
        var index = GameplayComponentsLookup.TransformMdl;
        var component = (EcsSupport.UnityIntegration.Models.TransformMdl)CreateComponent(index, typeof(EcsSupport.UnityIntegration.Models.TransformMdl));
        component.transform = newTransform;
        component.initialLocalRotation = newInitialLocalRotation;
        component.initialLocalPosition = newInitialLocalPosition;
        ReplaceComponent(index, component);
    }

    public void RemoveTransformMdl() {
        RemoveComponent(GameplayComponentsLookup.TransformMdl);
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

    static Entitas.IMatcher<GameplayEntity> _matcherTransformMdl;

    public static Entitas.IMatcher<GameplayEntity> TransformMdl {
        get {
            if (_matcherTransformMdl == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.TransformMdl);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherTransformMdl = matcher;
            }

            return _matcherTransformMdl;
        }
    }
}
