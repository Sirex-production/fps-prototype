//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayContext {

    public GameplayEntity uiDeadScreenMdlEntity { get { return GetGroup(GameplayMatcher.UiDeadScreenMdl).GetSingleEntity(); } }
    public Ingame.DeadScreen.UiDeadScreenMdl uiDeadScreenMdl { get { return uiDeadScreenMdlEntity.uiDeadScreenMdl; } }
    public bool hasUiDeadScreenMdl { get { return uiDeadScreenMdlEntity != null; } }

    public GameplayEntity SetUiDeadScreenMdl(Ingame.DeadScreen.UiDeadScreen newUiDeadScreen) {
        if (hasUiDeadScreenMdl) {
            throw new Entitas.EntitasException("Could not set UiDeadScreenMdl!\n" + this + " already has an entity with Ingame.DeadScreen.UiDeadScreenMdl!",
                "You should check if the context already has a uiDeadScreenMdlEntity before setting it or use context.ReplaceUiDeadScreenMdl().");
        }
        var entity = CreateEntity();
        entity.AddUiDeadScreenMdl(newUiDeadScreen);
        return entity;
    }

    public void ReplaceUiDeadScreenMdl(Ingame.DeadScreen.UiDeadScreen newUiDeadScreen) {
        var entity = uiDeadScreenMdlEntity;
        if (entity == null) {
            entity = SetUiDeadScreenMdl(newUiDeadScreen);
        } else {
            entity.ReplaceUiDeadScreenMdl(newUiDeadScreen);
        }
    }

    public void RemoveUiDeadScreenMdl() {
        uiDeadScreenMdlEntity.Destroy();
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

    public Ingame.DeadScreen.UiDeadScreenMdl uiDeadScreenMdl { get { return (Ingame.DeadScreen.UiDeadScreenMdl)GetComponent(GameplayComponentsLookup.UiDeadScreenMdl); } }
    public bool hasUiDeadScreenMdl { get { return HasComponent(GameplayComponentsLookup.UiDeadScreenMdl); } }

    public void AddUiDeadScreenMdl(Ingame.DeadScreen.UiDeadScreen newUiDeadScreen) {
        var index = GameplayComponentsLookup.UiDeadScreenMdl;
        var component = (Ingame.DeadScreen.UiDeadScreenMdl)CreateComponent(index, typeof(Ingame.DeadScreen.UiDeadScreenMdl));
        component.uiDeadScreen = newUiDeadScreen;
        AddComponent(index, component);
    }

    public void ReplaceUiDeadScreenMdl(Ingame.DeadScreen.UiDeadScreen newUiDeadScreen) {
        var index = GameplayComponentsLookup.UiDeadScreenMdl;
        var component = (Ingame.DeadScreen.UiDeadScreenMdl)CreateComponent(index, typeof(Ingame.DeadScreen.UiDeadScreenMdl));
        component.uiDeadScreen = newUiDeadScreen;
        ReplaceComponent(index, component);
    }

    public void RemoveUiDeadScreenMdl() {
        RemoveComponent(GameplayComponentsLookup.UiDeadScreenMdl);
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

    static Entitas.IMatcher<GameplayEntity> _matcherUiDeadScreenMdl;

    public static Entitas.IMatcher<GameplayEntity> UiDeadScreenMdl {
        get {
            if (_matcherUiDeadScreenMdl == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.UiDeadScreenMdl);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherUiDeadScreenMdl = matcher;
            }

            return _matcherUiDeadScreenMdl;
        }
    }
}
