//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class UpdateSettingsEventEventSystem : Entitas.ReactiveSystem<AppEntity> {

    readonly System.Collections.Generic.List<IUpdateSettingsEventListener> _listenerBuffer;

    public UpdateSettingsEventEventSystem(Contexts contexts) : base(contexts.app) {
        _listenerBuffer = new System.Collections.Generic.List<IUpdateSettingsEventListener>();
    }

    protected override Entitas.ICollector<AppEntity> GetTrigger(Entitas.IContext<AppEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(AppMatcher.UpdateSettingsEvent)
        );
    }

    protected override bool Filter(AppEntity entity) {
        return entity.isUpdateSettingsEvent && entity.hasUpdateSettingsEventListener;
    }

    protected override void Execute(System.Collections.Generic.List<AppEntity> entities) {
        foreach (var e in entities) {
            
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.updateSettingsEventListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnUpdateSettingsEvent(e);
            }
        }
    }
}
