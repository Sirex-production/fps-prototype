//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class AppEntity {

    static readonly Source.Ingame.Settings.Core.UpdateSettingsEvent updateSettingsEventComponent = new Source.Ingame.Settings.Core.UpdateSettingsEvent();

    public bool isUpdateSettingsEvent {
        get { return HasComponent(AppComponentsLookup.UpdateSettingsEvent); }
        set {
            if (value != isUpdateSettingsEvent) {
                var index = AppComponentsLookup.UpdateSettingsEvent;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : updateSettingsEventComponent;

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
public sealed partial class AppMatcher {

    static Entitas.IMatcher<AppEntity> _matcherUpdateSettingsEvent;

    public static Entitas.IMatcher<AppEntity> UpdateSettingsEvent {
        get {
            if (_matcherUpdateSettingsEvent == null) {
                var matcher = (Entitas.Matcher<AppEntity>)Entitas.Matcher<AppEntity>.AllOf(AppComponentsLookup.UpdateSettingsEvent);
                matcher.componentNames = AppComponentsLookup.componentNames;
                _matcherUpdateSettingsEvent = matcher;
            }

            return _matcherUpdateSettingsEvent;
        }
    }
}
