//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayContext {

    public GameplayEntity uiPlayerAbilitiesViewMdlEntity { get { return GetGroup(GameplayMatcher.UiPlayerAbilitiesViewMdl).GetSingleEntity(); } }
    public Ingame.Player.Abilities.UI.UiPlayerAbilitiesViewMdl uiPlayerAbilitiesViewMdl { get { return uiPlayerAbilitiesViewMdlEntity.uiPlayerAbilitiesViewMdl; } }
    public bool hasUiPlayerAbilitiesViewMdl { get { return uiPlayerAbilitiesViewMdlEntity != null; } }

    public GameplayEntity SetUiPlayerAbilitiesViewMdl(Ingame.Player.Abilities.UI.UiPlayerAbilitiesView newAbilitiesView) {
        if (hasUiPlayerAbilitiesViewMdl) {
            throw new Entitas.EntitasException("Could not set UiPlayerAbilitiesViewMdl!\n" + this + " already has an entity with Ingame.Player.Abilities.UI.UiPlayerAbilitiesViewMdl!",
                "You should check if the context already has a uiPlayerAbilitiesViewMdlEntity before setting it or use context.ReplaceUiPlayerAbilitiesViewMdl().");
        }
        var entity = CreateEntity();
        entity.AddUiPlayerAbilitiesViewMdl(newAbilitiesView);
        return entity;
    }

    public void ReplaceUiPlayerAbilitiesViewMdl(Ingame.Player.Abilities.UI.UiPlayerAbilitiesView newAbilitiesView) {
        var entity = uiPlayerAbilitiesViewMdlEntity;
        if (entity == null) {
            entity = SetUiPlayerAbilitiesViewMdl(newAbilitiesView);
        } else {
            entity.ReplaceUiPlayerAbilitiesViewMdl(newAbilitiesView);
        }
    }

    public void RemoveUiPlayerAbilitiesViewMdl() {
        uiPlayerAbilitiesViewMdlEntity.Destroy();
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

    public Ingame.Player.Abilities.UI.UiPlayerAbilitiesViewMdl uiPlayerAbilitiesViewMdl { get { return (Ingame.Player.Abilities.UI.UiPlayerAbilitiesViewMdl)GetComponent(GameplayComponentsLookup.UiPlayerAbilitiesViewMdl); } }
    public bool hasUiPlayerAbilitiesViewMdl { get { return HasComponent(GameplayComponentsLookup.UiPlayerAbilitiesViewMdl); } }

    public void AddUiPlayerAbilitiesViewMdl(Ingame.Player.Abilities.UI.UiPlayerAbilitiesView newAbilitiesView) {
        var index = GameplayComponentsLookup.UiPlayerAbilitiesViewMdl;
        var component = (Ingame.Player.Abilities.UI.UiPlayerAbilitiesViewMdl)CreateComponent(index, typeof(Ingame.Player.Abilities.UI.UiPlayerAbilitiesViewMdl));
        component.abilitiesView = newAbilitiesView;
        AddComponent(index, component);
    }

    public void ReplaceUiPlayerAbilitiesViewMdl(Ingame.Player.Abilities.UI.UiPlayerAbilitiesView newAbilitiesView) {
        var index = GameplayComponentsLookup.UiPlayerAbilitiesViewMdl;
        var component = (Ingame.Player.Abilities.UI.UiPlayerAbilitiesViewMdl)CreateComponent(index, typeof(Ingame.Player.Abilities.UI.UiPlayerAbilitiesViewMdl));
        component.abilitiesView = newAbilitiesView;
        ReplaceComponent(index, component);
    }

    public void RemoveUiPlayerAbilitiesViewMdl() {
        RemoveComponent(GameplayComponentsLookup.UiPlayerAbilitiesViewMdl);
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

    static Entitas.IMatcher<GameplayEntity> _matcherUiPlayerAbilitiesViewMdl;

    public static Entitas.IMatcher<GameplayEntity> UiPlayerAbilitiesViewMdl {
        get {
            if (_matcherUiPlayerAbilitiesViewMdl == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.UiPlayerAbilitiesViewMdl);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherUiPlayerAbilitiesViewMdl = matcher;
            }

            return _matcherUiPlayerAbilitiesViewMdl;
        }
    }
}