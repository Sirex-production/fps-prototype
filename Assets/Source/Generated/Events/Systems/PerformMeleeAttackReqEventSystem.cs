//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class PerformMeleeAttackReqEventSystem : Entitas.ReactiveSystem<GameplayEntity> {

    readonly System.Collections.Generic.List<IPerformMeleeAttackReqListener> _listenerBuffer;

    public PerformMeleeAttackReqEventSystem(Contexts contexts) : base(contexts.gameplay) {
        _listenerBuffer = new System.Collections.Generic.List<IPerformMeleeAttackReqListener>();
    }

    protected override Entitas.ICollector<GameplayEntity> GetTrigger(Entitas.IContext<GameplayEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameplayMatcher.PerformMeleeAttackReq)
        );
    }

    protected override bool Filter(GameplayEntity entity) {
        return entity.hasPerformMeleeAttackReq && entity.hasPerformMeleeAttackReqListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameplayEntity> entities) {
        foreach (var e in entities) {
            var component = e.performMeleeAttackReq;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.performMeleeAttackReqListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnPerformMeleeAttackReq(e, component.range, component.damage);
            }
        }
    }
}
