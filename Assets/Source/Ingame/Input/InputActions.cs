//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.0
//     from Assets/Configs/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Ingame.Input
{
    public partial class @InputActions: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""678df3fb-1aa7-4f28-8d7a-c4cde3224e34"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""464a937a-9d15-4b98-b86c-ad821e50e9a8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""cb3b9b70-38d0-4a1a-9884-675d232bdbf6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""293dd383-3878-4ce8-a14a-5af5038eac26"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""49b55185-67ed-43d7-9951-801edd3c3ebb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ed4eca43-7c0e-4644-9a29-885dd1db6525"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2a445266-c264-4358-8619-76baeda30c5a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c46d6195-589a-4334-b296-d91dd12dc509"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""14cd8612-d827-426d-bc61-bbd5ce1edd93"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""eed004a6-80f5-44e1-9d8e-be5da46012b6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1a781324-ff17-4c47-b4ae-0821742bc4cd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ab79eaba-cc07-4b52-a835-2eb585a908cf"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""295720c9-1c2b-4c64-8b2a-8a813651ddcf"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Combat"",
            ""id"": ""d670d018-e7d2-4ad8-8a44-f184692e7b52"",
            ""actions"": [
                {
                    ""name"": ""NextWeapon"",
                    ""type"": ""Value"",
                    ""id"": ""a1bb1036-1bf4-4483-924e-507a54f7cb1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PrevWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""58b3ab39-1002-43fc-8a6c-23d155903872"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""9aea2577-ef44-43b3-9e1a-605346c68849"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7520597d-b06e-4619-88c3-dab265b58a2c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d50e359-c5f0-4ef1-8168-8dc6fc3cf324"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd8d47f2-1f18-4178-90bc-ca96ea79e7e5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Movement
            m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
            m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
            m_Movement_Rotate = m_Movement.FindAction("Rotate", throwIfNotFound: true);
            m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
            m_Movement_Dash = m_Movement.FindAction("Dash", throwIfNotFound: true);
            // Combat
            m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
            m_Combat_NextWeapon = m_Combat.FindAction("NextWeapon", throwIfNotFound: true);
            m_Combat_PrevWeapon = m_Combat.FindAction("PrevWeapon", throwIfNotFound: true);
            m_Combat_Shoot = m_Combat.FindAction("Shoot", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Movement
        private readonly InputActionMap m_Movement;
        private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
        private readonly InputAction m_Movement_Move;
        private readonly InputAction m_Movement_Rotate;
        private readonly InputAction m_Movement_Jump;
        private readonly InputAction m_Movement_Dash;
        public struct MovementActions
        {
            private @InputActions m_Wrapper;
            public MovementActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Movement_Move;
            public InputAction @Rotate => m_Wrapper.m_Movement_Rotate;
            public InputAction @Jump => m_Wrapper.m_Movement_Jump;
            public InputAction @Dash => m_Wrapper.m_Movement_Dash;
            public InputActionMap Get() { return m_Wrapper.m_Movement; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
            public void AddCallbacks(IMovementActions instance)
            {
                if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }

            private void UnregisterCallbacks(IMovementActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Rotate.started -= instance.OnRotate;
                @Rotate.performed -= instance.OnRotate;
                @Rotate.canceled -= instance.OnRotate;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @Dash.started -= instance.OnDash;
                @Dash.performed -= instance.OnDash;
                @Dash.canceled -= instance.OnDash;
            }

            public void RemoveCallbacks(IMovementActions instance)
            {
                if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IMovementActions instance)
            {
                foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public MovementActions @Movement => new MovementActions(this);

        // Combat
        private readonly InputActionMap m_Combat;
        private List<ICombatActions> m_CombatActionsCallbackInterfaces = new List<ICombatActions>();
        private readonly InputAction m_Combat_NextWeapon;
        private readonly InputAction m_Combat_PrevWeapon;
        private readonly InputAction m_Combat_Shoot;
        public struct CombatActions
        {
            private @InputActions m_Wrapper;
            public CombatActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @NextWeapon => m_Wrapper.m_Combat_NextWeapon;
            public InputAction @PrevWeapon => m_Wrapper.m_Combat_PrevWeapon;
            public InputAction @Shoot => m_Wrapper.m_Combat_Shoot;
            public InputActionMap Get() { return m_Wrapper.m_Combat; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
            public void AddCallbacks(ICombatActions instance)
            {
                if (instance == null || m_Wrapper.m_CombatActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_CombatActionsCallbackInterfaces.Add(instance);
                @NextWeapon.started += instance.OnNextWeapon;
                @NextWeapon.performed += instance.OnNextWeapon;
                @NextWeapon.canceled += instance.OnNextWeapon;
                @PrevWeapon.started += instance.OnPrevWeapon;
                @PrevWeapon.performed += instance.OnPrevWeapon;
                @PrevWeapon.canceled += instance.OnPrevWeapon;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }

            private void UnregisterCallbacks(ICombatActions instance)
            {
                @NextWeapon.started -= instance.OnNextWeapon;
                @NextWeapon.performed -= instance.OnNextWeapon;
                @NextWeapon.canceled -= instance.OnNextWeapon;
                @PrevWeapon.started -= instance.OnPrevWeapon;
                @PrevWeapon.performed -= instance.OnPrevWeapon;
                @PrevWeapon.canceled -= instance.OnPrevWeapon;
                @Shoot.started -= instance.OnShoot;
                @Shoot.performed -= instance.OnShoot;
                @Shoot.canceled -= instance.OnShoot;
            }

            public void RemoveCallbacks(ICombatActions instance)
            {
                if (m_Wrapper.m_CombatActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ICombatActions instance)
            {
                foreach (var item in m_Wrapper.m_CombatActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_CombatActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public CombatActions @Combat => new CombatActions(this);
        public interface IMovementActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnRotate(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
        }
        public interface ICombatActions
        {
            void OnNextWeapon(InputAction.CallbackContext context);
            void OnPrevWeapon(InputAction.CallbackContext context);
            void OnShoot(InputAction.CallbackContext context);
        }
    }
}
