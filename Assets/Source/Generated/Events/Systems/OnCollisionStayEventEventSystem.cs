//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class OnCollisionStayEventEventSystem : Entitas.ReactiveSystem<GameplayEntity> {

    readonly System.Collections.Generic.List<IOnCollisionStayEventListener> _listenerBuffer;

    public OnCollisionStayEventEventSystem(Contexts contexts) : base(contexts.gameplay) {
        _listenerBuffer = new System.Collections.Generic.List<IOnCollisionStayEventListener>();
    }

    protected override Entitas.ICollector<GameplayEntity> GetTrigger(Entitas.IContext<GameplayEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameplayMatcher.OnCollisionStayEvent)
        );
    }

    protected override bool Filter(GameplayEntity entity) {
        return entity.hasOnCollisionStayEvent && entity.hasOnCollisionStayEventListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameplayEntity> entities) {
        foreach (var e in entities) {
            var component = e.onCollisionStayEvent;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.onCollisionStayEventListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnOnCollisionStayEvent(e, component.other, component.sender);
            }
        }
    }
}
