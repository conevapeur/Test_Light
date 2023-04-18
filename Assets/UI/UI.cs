//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/UI/UI.inputactions
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

public partial class @UI : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @UI()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UI"",
    ""maps"": [
        {
            ""name"": ""Menu"",
            ""id"": ""dedb593e-a6d0-410a-b6a5-a0e59d9c3cd0"",
            ""actions"": [
                {
                    ""name"": ""escape"",
                    ""type"": ""Button"",
                    ""id"": ""88535111-921b-4aa6-9a81-1ff88c0da5c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""back"",
                    ""type"": ""Button"",
                    ""id"": ""c13a86c9-c5ac-47a3-be4f-f720ba8121c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9048fcff-5b91-41c5-8bbc-6b9712eadbca"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cc847ac-c2c4-494f-8a69-572b6c743662"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c779e5b0-f0fd-49ab-ba3c-a29f8736b406"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfcc73de-2520-4b8b-bbfa-b5f33c588d65"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ActionTest"",
            ""id"": ""1a0f9b3e-63fd-4c9b-859d-f8fc3005bc96"",
            ""actions"": [
                {
                    ""name"": ""interact"",
                    ""type"": ""Button"",
                    ""id"": ""65057a85-5af6-4afe-add7-a58c5a7cb2c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3c76adaf-0bef-4518-99b0-7286fd94257e"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_escape = m_Menu.FindAction("escape", throwIfNotFound: true);
        m_Menu_back = m_Menu.FindAction("back", throwIfNotFound: true);
        // ActionTest
        m_ActionTest = asset.FindActionMap("ActionTest", throwIfNotFound: true);
        m_ActionTest_interact = m_ActionTest.FindAction("interact", throwIfNotFound: true);
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

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_escape;
    private readonly InputAction m_Menu_back;
    public struct MenuActions
    {
        private @UI m_Wrapper;
        public MenuActions(@UI wrapper) { m_Wrapper = wrapper; }
        public InputAction @escape => m_Wrapper.m_Menu_escape;
        public InputAction @back => m_Wrapper.m_Menu_back;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @escape.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnEscape;
                @escape.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnEscape;
                @escape.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnEscape;
                @back.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                @back.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                @back.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @escape.started += instance.OnEscape;
                @escape.performed += instance.OnEscape;
                @escape.canceled += instance.OnEscape;
                @back.started += instance.OnBack;
                @back.performed += instance.OnBack;
                @back.canceled += instance.OnBack;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);

    // ActionTest
    private readonly InputActionMap m_ActionTest;
    private IActionTestActions m_ActionTestActionsCallbackInterface;
    private readonly InputAction m_ActionTest_interact;
    public struct ActionTestActions
    {
        private @UI m_Wrapper;
        public ActionTestActions(@UI wrapper) { m_Wrapper = wrapper; }
        public InputAction @interact => m_Wrapper.m_ActionTest_interact;
        public InputActionMap Get() { return m_Wrapper.m_ActionTest; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionTestActions set) { return set.Get(); }
        public void SetCallbacks(IActionTestActions instance)
        {
            if (m_Wrapper.m_ActionTestActionsCallbackInterface != null)
            {
                @interact.started -= m_Wrapper.m_ActionTestActionsCallbackInterface.OnInteract;
                @interact.performed -= m_Wrapper.m_ActionTestActionsCallbackInterface.OnInteract;
                @interact.canceled -= m_Wrapper.m_ActionTestActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_ActionTestActionsCallbackInterface = instance;
            if (instance != null)
            {
                @interact.started += instance.OnInteract;
                @interact.performed += instance.OnInteract;
                @interact.canceled += instance.OnInteract;
            }
        }
    }
    public ActionTestActions @ActionTest => new ActionTestActions(this);
    public interface IMenuActions
    {
        void OnEscape(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
    public interface IActionTestActions
    {
        void OnInteract(InputAction.CallbackContext context);
    }
}
