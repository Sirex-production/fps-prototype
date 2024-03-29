//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayContext {

    public GameplayEntity hudRecoilCmpEntity { get { return GetGroup(GameplayMatcher.HudRecoilCmp).GetSingleEntity(); } }
    public Ingame.Camerawork.Recoil.HudRecoilCmp hudRecoilCmp { get { return hudRecoilCmpEntity.hudRecoilCmp; } }
    public bool hasHudRecoilCmp { get { return hudRecoilCmpEntity != null; } }

    public GameplayEntity SetHudRecoilCmp(UnityEngine.Vector2 newCurrentRecoilOffset) {
        if (hasHudRecoilCmp) {
            throw new Entitas.EntitasException("Could not set HudRecoilCmp!\n" + this + " already has an entity with Ingame.Camerawork.Recoil.HudRecoilCmp!",
                "You should check if the context already has a hudRecoilCmpEntity before setting it or use context.ReplaceHudRecoilCmp().");
        }
        var entity = CreateEntity();
        entity.AddHudRecoilCmp(newCurrentRecoilOffset);
        return entity;
    }

    public void ReplaceHudRecoilCmp(UnityEngine.Vector2 newCurrentRecoilOffset) {
        var entity = hudRecoilCmpEntity;
        if (entity == null) {
            entity = SetHudRecoilCmp(newCurrentRecoilOffset);
        } else {
            entity.ReplaceHudRecoilCmp(newCurrentRecoilOffset);
        }
    }

    public void RemoveHudRecoilCmp() {
        hudRecoilCmpEntity.Destroy();
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

    public Ingame.Camerawork.Recoil.HudRecoilCmp hudRecoilCmp { get { return (Ingame.Camerawork.Recoil.HudRecoilCmp)GetComponent(GameplayComponentsLookup.HudRecoilCmp); } }
    public bool hasHudRecoilCmp { get { return HasComponent(GameplayComponentsLookup.HudRecoilCmp); } }

    public void AddHudRecoilCmp(UnityEngine.Vector2 newCurrentRecoilOffset) {
        var index = GameplayComponentsLookup.HudRecoilCmp;
        var component = (Ingame.Camerawork.Recoil.HudRecoilCmp)CreateComponent(index, typeof(Ingame.Camerawork.Recoil.HudRecoilCmp));
        component.currentRecoilOffset = newCurrentRecoilOffset;
        AddComponent(index, component);
    }

    public void ReplaceHudRecoilCmp(UnityEngine.Vector2 newCurrentRecoilOffset) {
        var index = GameplayComponentsLookup.HudRecoilCmp;
        var component = (Ingame.Camerawork.Recoil.HudRecoilCmp)CreateComponent(index, typeof(Ingame.Camerawork.Recoil.HudRecoilCmp));
        component.currentRecoilOffset = newCurrentRecoilOffset;
        ReplaceComponent(index, component);
    }

    public void RemoveHudRecoilCmp() {
        RemoveComponent(GameplayComponentsLookup.HudRecoilCmp);
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

    static Entitas.IMatcher<GameplayEntity> _matcherHudRecoilCmp;

    public static Entitas.IMatcher<GameplayEntity> HudRecoilCmp {
        get {
            if (_matcherHudRecoilCmp == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.HudRecoilCmp);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherHudRecoilCmp = matcher;
            }

            return _matcherHudRecoilCmp;
        }
    }
}
