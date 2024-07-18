using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameInput
{
    public enum MouseButton
    {
        Left, Right
    }

    public class MouseUser : MonoBehaviour
    {
        private InputAction _inputAction;

        public Vector2 MousePosition { get; private set; }
        public Vector2 MouseInWorldPosition => Camera.main.ScreenToWorldPoint(MousePosition);

        private bool _isLeftMouseButtonPressed;
        private bool _isRightMouseButtonPressed;

        private void OnEnable()
        {
            _inputAction = InputAction.Instance;
            _inputAction.Game.MousePosition.performed += OnMousePositionPerformed;

            // Assuming you have actions defined for mouse button presses
            _inputAction.Game.PerformAction.started += OnPerformActionStarted;
            _inputAction.Game.PerformAction.canceled += OnPerformActionCanceled;
            _inputAction.Game.CancelledAction.started += OnCancelledActionStarted;
            _inputAction.Game.CancelledAction.canceled += OnCancelledActionCanceled;
        }

        private void OnDisable()
        {
            _inputAction.Game.MousePosition.performed -= OnMousePositionPerformed;

            _inputAction.Game.PerformAction.started -= OnPerformActionStarted;
            _inputAction.Game.PerformAction.canceled -= OnPerformActionCanceled;
            _inputAction.Game.CancelledAction.started -= OnCancelledActionStarted;
            _inputAction.Game.CancelledAction.canceled -= OnCancelledActionCanceled;
        }

        private void OnMousePositionPerformed(InputAction.CallbackContext ctx)
        {
            MousePosition = ctx.ReadValue<Vector2>();
        }

        private void OnPerformActionStarted(InputAction.CallbackContext ctx)
        {
            _isLeftMouseButtonPressed = true;
        }

        private void OnPerformActionCanceled(InputAction.CallbackContext ctx)
        {
            _isLeftMouseButtonPressed = false;
        }

        private void OnCancelledActionStarted(InputAction.CallbackContext ctx)
        {
            _isRightMouseButtonPressed = true;
        }

        private void OnCancelledActionCanceled(InputAction.CallbackContext ctx)
        {
            _isRightMouseButtonPressed = false;
        }

        public bool IsMouseButtonPressed(MouseButton button)
        {
            return button == MouseButton.Left ? _isLeftMouseButtonPressed : _isRightMouseButtonPressed;
        }
    }
}
