//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayContext {

    public GameplayEntity hookTargetCmpEntity { get { return GetGroup(GameplayMatcher.HookTargetCmp).GetSingleEntity(); } }
    public Ingame.Player.Abilities.Hook.HookTargetCmp hookTargetCmp { get { return hookTargetCmpEntity.hookTargetCmp; } }
    public bool hasHookTargetCmp { get { return hookTargetCmpEntity != null; } }

    public GameplayEntity SetHookTargetCmp(Ingame.Player.Abilities.Hook.HookTargetCmp.HookType newHookType) {
        if (hasHookTargetCmp) {
            throw new Entitas.EntitasException("Could not set HookTargetCmp!\n" + this + " already has an entity with Ingame.Player.Abilities.Hook.HookTargetCmp!",
                "You should check if the context already has a hookTargetCmpEntity before setting it or use context.ReplaceHookTargetCmp().");
        }
        var entity = CreateEntity();
        entity.AddHookTargetCmp(newHookType);
        return entity;
    }

    public void ReplaceHookTargetCmp(Ingame.Player.Abilities.Hook.HookTargetCmp.HookType newHookType) {
        var entity = hookTargetCmpEntity;
        if (entity == null) {
            entity = SetHookTargetCmp(newHookType);
        } else {
            entity.ReplaceHookTargetCmp(newHookType);
        }
    }

    public void RemoveHookTargetCmp() {
        hookTargetCmpEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public Ingame.Player.Abilities.Hook.HookTargetCmp hookTargetCmp { get { return (Ingame.Player.Abilities.Hook.HookTargetCmp)GetComponent(GameplayComponentsLookup.HookTargetCmp); } }
    public bool hasHookTargetCmp { get { return HasComponent(GameplayComponentsLookup.HookTargetCmp); } }

    public void AddHookTargetCmp(Ingame.Player.Abilities.Hook.HookTargetCmp.HookType newHookType) {
        var index = GameplayComponentsLookup.HookTargetCmp;
        var component = (Ingame.Player.Abilities.Hook.HookTargetCmp)CreateComponent(index, typeof(Ingame.Player.Abilities.Hook.HookTargetCmp));
        component.hookType = newHookType;
        AddComponent(index, component);
    }

    public void ReplaceHookTargetCmp(Ingame.Player.Abilities.Hook.HookTargetCmp.HookType newHookType) {
        var index = GameplayComponentsLookup.HookTargetCmp;
        var component = (Ingame.Player.Abilities.Hook.HookTargetCmp)CreateComponent(index, typeof(Ingame.Player.Abilities.Hook.HookTargetCmp));
        component.hookType = newHookType;
        ReplaceComponent(index, component);
    }

    public void RemoveHookTargetCmp() {
        RemoveComponent(GameplayComponentsLookup.HookTargetCmp);
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

    static Entitas.IMatcher<GameplayEntity> _matcherHookTargetCmp;

    public static Entitas.IMatcher<GameplayEntity> HookTargetCmp {
        get {
            if (_matcherHookTargetCmp == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.HookTargetCmp);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherHookTargetCmp = matcher;
            }

            return _matcherHookTargetCmp;
        }
    }
}
