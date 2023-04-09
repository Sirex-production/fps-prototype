//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class AppContext {

    public AppEntity inputCmpEntity { get { return GetGroup(AppMatcher.InputCmp).GetSingleEntity(); } }
    public Ingame.Input.InputCmp inputCmp { get { return inputCmpEntity.inputCmp; } }
    public bool hasInputCmp { get { return inputCmpEntity != null; } }

    public AppEntity SetInputCmp(UnityEngine.Vector2 newMoveInput, UnityEngine.Vector2 newRotateInput, bool newJumpInput, bool newDashInput, bool newNextWeaponInput, bool newPrevWeaponInput, int newSelectWeaponInput, bool newShootHoldInput, bool newShootTapInput, bool newAimHoldInput, bool newAimTapInput) {
        if (hasInputCmp) {
            throw new Entitas.EntitasException("Could not set InputCmp!\n" + this + " already has an entity with Ingame.Input.InputCmp!",
                "You should check if the context already has a inputCmpEntity before setting it or use context.ReplaceInputCmp().");
        }
        var entity = CreateEntity();
        entity.AddInputCmp(newMoveInput, newRotateInput, newJumpInput, newDashInput, newNextWeaponInput, newPrevWeaponInput, newSelectWeaponInput, newShootHoldInput, newShootTapInput, newAimHoldInput, newAimTapInput);
        return entity;
    }

    public void ReplaceInputCmp(UnityEngine.Vector2 newMoveInput, UnityEngine.Vector2 newRotateInput, bool newJumpInput, bool newDashInput, bool newNextWeaponInput, bool newPrevWeaponInput, int newSelectWeaponInput, bool newShootHoldInput, bool newShootTapInput, bool newAimHoldInput, bool newAimTapInput) {
        var entity = inputCmpEntity;
        if (entity == null) {
            entity = SetInputCmp(newMoveInput, newRotateInput, newJumpInput, newDashInput, newNextWeaponInput, newPrevWeaponInput, newSelectWeaponInput, newShootHoldInput, newShootTapInput, newAimHoldInput, newAimTapInput);
        } else {
            entity.ReplaceInputCmp(newMoveInput, newRotateInput, newJumpInput, newDashInput, newNextWeaponInput, newPrevWeaponInput, newSelectWeaponInput, newShootHoldInput, newShootTapInput, newAimHoldInput, newAimTapInput);
        }
    }

    public void RemoveInputCmp() {
        inputCmpEntity.Destroy();
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
public partial class AppEntity {

    public Ingame.Input.InputCmp inputCmp { get { return (Ingame.Input.InputCmp)GetComponent(AppComponentsLookup.InputCmp); } }
    public bool hasInputCmp { get { return HasComponent(AppComponentsLookup.InputCmp); } }

    public void AddInputCmp(UnityEngine.Vector2 newMoveInput, UnityEngine.Vector2 newRotateInput, bool newJumpInput, bool newDashInput, bool newNextWeaponInput, bool newPrevWeaponInput, int newSelectWeaponInput, bool newShootHoldInput, bool newShootTapInput, bool newAimHoldInput, bool newAimTapInput) {
        var index = AppComponentsLookup.InputCmp;
        var component = (Ingame.Input.InputCmp)CreateComponent(index, typeof(Ingame.Input.InputCmp));
        component.moveInput = newMoveInput;
        component.rotateInput = newRotateInput;
        component.jumpInput = newJumpInput;
        component.dashInput = newDashInput;
        component.nextWeaponInput = newNextWeaponInput;
        component.prevWeaponInput = newPrevWeaponInput;
        component.selectWeaponInput = newSelectWeaponInput;
        component.shootHoldInput = newShootHoldInput;
        component.shootTapInput = newShootTapInput;
        component.aimHoldInput = newAimHoldInput;
        component.aimTapInput = newAimTapInput;
        AddComponent(index, component);
    }

    public void ReplaceInputCmp(UnityEngine.Vector2 newMoveInput, UnityEngine.Vector2 newRotateInput, bool newJumpInput, bool newDashInput, bool newNextWeaponInput, bool newPrevWeaponInput, int newSelectWeaponInput, bool newShootHoldInput, bool newShootTapInput, bool newAimHoldInput, bool newAimTapInput) {
        var index = AppComponentsLookup.InputCmp;
        var component = (Ingame.Input.InputCmp)CreateComponent(index, typeof(Ingame.Input.InputCmp));
        component.moveInput = newMoveInput;
        component.rotateInput = newRotateInput;
        component.jumpInput = newJumpInput;
        component.dashInput = newDashInput;
        component.nextWeaponInput = newNextWeaponInput;
        component.prevWeaponInput = newPrevWeaponInput;
        component.selectWeaponInput = newSelectWeaponInput;
        component.shootHoldInput = newShootHoldInput;
        component.shootTapInput = newShootTapInput;
        component.aimHoldInput = newAimHoldInput;
        component.aimTapInput = newAimTapInput;
        ReplaceComponent(index, component);
    }

    public void RemoveInputCmp() {
        RemoveComponent(AppComponentsLookup.InputCmp);
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

    static Entitas.IMatcher<AppEntity> _matcherInputCmp;

    public static Entitas.IMatcher<AppEntity> InputCmp {
        get {
            if (_matcherInputCmp == null) {
                var matcher = (Entitas.Matcher<AppEntity>)Entitas.Matcher<AppEntity>.AllOf(AppComponentsLookup.InputCmp);
                matcher.componentNames = AppComponentsLookup.componentNames;
                _matcherInputCmp = matcher;
            }

            return _matcherInputCmp;
        }
    }
}
