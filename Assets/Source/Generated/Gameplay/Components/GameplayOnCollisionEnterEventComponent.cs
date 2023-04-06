//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public EcsSupport.UnityIntegration.Physics.OnCollisionEnterEvent onCollisionEnterEvent { get { return (EcsSupport.UnityIntegration.Physics.OnCollisionEnterEvent)GetComponent(GameplayComponentsLookup.OnCollisionEnterEvent); } }
    public bool hasOnCollisionEnterEvent { get { return HasComponent(GameplayComponentsLookup.OnCollisionEnterEvent); } }

    public void AddOnCollisionEnterEvent(UnityEngine.Collision newOther, UnityEngine.Collider newSender) {
        var index = GameplayComponentsLookup.OnCollisionEnterEvent;
        var component = (EcsSupport.UnityIntegration.Physics.OnCollisionEnterEvent)CreateComponent(index, typeof(EcsSupport.UnityIntegration.Physics.OnCollisionEnterEvent));
        component.other = newOther;
        component.sender = newSender;
        AddComponent(index, component);
    }

    public void ReplaceOnCollisionEnterEvent(UnityEngine.Collision newOther, UnityEngine.Collider newSender) {
        var index = GameplayComponentsLookup.OnCollisionEnterEvent;
        var component = (EcsSupport.UnityIntegration.Physics.OnCollisionEnterEvent)CreateComponent(index, typeof(EcsSupport.UnityIntegration.Physics.OnCollisionEnterEvent));
        component.other = newOther;
        component.sender = newSender;
        ReplaceComponent(index, component);
    }

    public void RemoveOnCollisionEnterEvent() {
        RemoveComponent(GameplayComponentsLookup.OnCollisionEnterEvent);
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

    static Entitas.IMatcher<GameplayEntity> _matcherOnCollisionEnterEvent;

    public static Entitas.IMatcher<GameplayEntity> OnCollisionEnterEvent {
        get {
            if (_matcherOnCollisionEnterEvent == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.OnCollisionEnterEvent);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherOnCollisionEnterEvent = matcher;
            }

            return _matcherOnCollisionEnterEvent;
        }
    }
}