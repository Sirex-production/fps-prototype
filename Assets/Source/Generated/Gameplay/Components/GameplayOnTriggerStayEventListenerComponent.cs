//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public OnTriggerStayEventListenerComponent onTriggerStayEventListener { get { return (OnTriggerStayEventListenerComponent)GetComponent(GameplayComponentsLookup.OnTriggerStayEventListener); } }
    public bool hasOnTriggerStayEventListener { get { return HasComponent(GameplayComponentsLookup.OnTriggerStayEventListener); } }

    public void AddOnTriggerStayEventListener(System.Collections.Generic.List<IOnTriggerStayEventListener> newValue) {
        var index = GameplayComponentsLookup.OnTriggerStayEventListener;
        var component = (OnTriggerStayEventListenerComponent)CreateComponent(index, typeof(OnTriggerStayEventListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceOnTriggerStayEventListener(System.Collections.Generic.List<IOnTriggerStayEventListener> newValue) {
        var index = GameplayComponentsLookup.OnTriggerStayEventListener;
        var component = (OnTriggerStayEventListenerComponent)CreateComponent(index, typeof(OnTriggerStayEventListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveOnTriggerStayEventListener() {
        RemoveComponent(GameplayComponentsLookup.OnTriggerStayEventListener);
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

    static Entitas.IMatcher<GameplayEntity> _matcherOnTriggerStayEventListener;

    public static Entitas.IMatcher<GameplayEntity> OnTriggerStayEventListener {
        get {
            if (_matcherOnTriggerStayEventListener == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.OnTriggerStayEventListener);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherOnTriggerStayEventListener = matcher;
            }

            return _matcherOnTriggerStayEventListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public void AddOnTriggerStayEventListener(IOnTriggerStayEventListener value) {
        var listeners = hasOnTriggerStayEventListener
            ? onTriggerStayEventListener.value
            : new System.Collections.Generic.List<IOnTriggerStayEventListener>();
        listeners.Add(value);
        ReplaceOnTriggerStayEventListener(listeners);
    }

    public void RemoveOnTriggerStayEventListener(IOnTriggerStayEventListener value, bool removeComponentWhenEmpty = true) {
        var listeners = onTriggerStayEventListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveOnTriggerStayEventListener();
        } else {
            ReplaceOnTriggerStayEventListener(listeners);
        }
    }
}