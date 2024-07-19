//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/InputAction.inputactions
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

namespace GameInput
{
    public partial class @InputAction : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputAction()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputAction"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""b176da31-ef29-4d88-a8e4-b7d3b39f2693"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""40d9fb0e-ac10-4edd-953a-b8640b8ec99f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PerformAction"",
                    ""type"": ""Button"",
                    ""id"": ""34ea8475-ba3a-468a-a8dd-94b90abc8363"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CancelAction"",
                    ""type"": ""Button"",
                    ""id"": ""c8daadbd-7be2-4025-8a94-c91835bce4ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8934fa06-9c4d-4b00-97ba-0b9f8cbb5fc0"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b524f0f7-8344-4e6f-a59e-a5835f3ea7db"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PerformAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c525ed0-2661-469f-9ec8-9df08ece5206"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Game
            m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
            m_Game_MousePosition = m_Game.FindAction("MousePosition", throwIfNotFound: true);
            m_Game_PerformAction = m_Game.FindAction("PerformAction", throwIfNotFound: true);
            m_Game_CancelAction = m_Game.FindAction("CancelAction", throwIfNotFound: true);
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

        UnityEngine.InputSystem.InputAction IInputActionCollection2.FindAction(string actionNameOrId, bool throwIfNotFound)
        {
            throw new NotImplementedException();
        }

        public int FindBinding(InputBinding mask, out UnityEngine.InputSystem.InputAction action)
        {
            throw new NotImplementedException();
        }

        public bool Contains(UnityEngine.InputSystem.InputAction action)
        {
            throw new NotImplementedException();
        }

        IEnumerator<UnityEngine.InputSystem.InputAction> IEnumerable<UnityEngine.InputSystem.InputAction>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        // Game

        private readonly InputActionMap m_Game;
        private List<IGameActions> m_GameActionsCallbackInterfaces = new List<IGameActions>();
        private Action<CallbackContext> started;
        private Action<CallbackContext> performed;
        private Action<CallbackContext> canceled;

        private readonly InputAction m_Game_MousePosition;
        private readonly InputAction m_Game_PerformAction;
        private readonly InputAction m_Game_CancelAction;
        public struct GameActions
        {
            private @InputAction m_Wrapper;
            public GameActions(@InputAction wrapper) { m_Wrapper = wrapper; }
            public InputAction @MousePosition => m_Wrapper.m_Game_MousePosition;
            public InputAction @PerformAction => m_Wrapper.m_Game_PerformAction;
            public InputAction @CancelAction => m_Wrapper.m_Game_CancelAction;
            public InputActionMap Get() { return m_Wrapper.m_Game; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
            public void AddCallbacks(IGameActions instance)
            {
                if (instance == null || m_Wrapper.m_GameActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_GameActionsCallbackInterfaces.Add(instance);
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @PerformAction.started += instance.OnPerformAction;
                @PerformAction.performed += instance.OnPerformAction;
                @PerformAction.canceled += instance.OnPerformAction;
                @CancelAction.started += instance.OnCancelAction;
                @CancelAction.performed += instance.OnCancelAction;
                @CancelAction.canceled += instance.OnCancelAction;
            }

            private void UnregisterCallbacks(IGameActions instance)
            {
                @MousePosition.started -= instance.OnMousePosition;
                @MousePosition.performed -= instance.OnMousePosition;
                @MousePosition.canceled -= instance.OnMousePosition;
                @PerformAction.started -= instance.OnPerformAction;
                @PerformAction.performed -= instance.OnPerformAction;
                @PerformAction.canceled -= instance.OnPerformAction;
                @CancelAction.started -= instance.OnCancelAction;
                @CancelAction.performed -= instance.OnCancelAction;
                @CancelAction.canceled -= instance.OnCancelAction;
            }

            public void RemoveCallbacks(IGameActions instance)
            {
                if (m_Wrapper.m_GameActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IGameActions instance)
            {
                foreach (var item in m_Wrapper.m_GameActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_GameActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public GameActions @Game => new GameActions(this);
        public interface IGameActions
        {
            void OnMousePosition(InputAction.CallbackContext context);
            void OnPerformAction(InputAction.CallbackContext context);
            void OnCancelAction(InputAction.CallbackContext context);
        }

        public class CallbackContext
        {
            public event Action<InputAction.CallbackContext> performed;
        }

    }
}
