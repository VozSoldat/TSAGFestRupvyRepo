using System;
using UnityEngine;

namespace GameInput
{

    public enum MouseButton
    {
        Left,
        Right
    }
    
    public class MouseUser : MonoBehaviour
    {
        private InputAction _inputAction;

        public Vector2 MousePosition { get; private set; }
        public Vector2 MouseInWorldPosition { get; private set; }

        private bool _isLeftMouseButtonPressed;
        private bool _isRightMouseButtonPressed;

        private void OnEnable()
        {
            _inputAction = new InputAction();
            _inputAction.Game.MousePosition.performed += OnMousePositionPerformed;
            _inputAction.Game.PerformAction.performed += OnPerformActionPerformed;
            _inputAction.Game.PerformAction.canceled += OnPerformActionCanceled;
            _inputAction.Game.CancelAction.performed += OnCancelActionPerformed;
            _inputAction.Game.CancelAction.canceled += OnCancelActionCanceled;
        }

        private void OnDisable()
        {
            _inputAction.Game.MousePosition.performed += OnMousePositionPerformed;
            _inputAction.Game.PerformAction.performed += OnPerformActionPerformed;
            _inputAction.Game.PerformAction.canceled += OnPerformActionCanceled;
            _inputAction.Game.CancelAction.performed += OnCancelActionPerformed;
            _inputAction.Game.CancelAction.canceled += OnCancelActionCanceled;        }

        private void OnMousePositionPerformed(InputAction.CallbackContext ctx)
        {
            MousePosition = ctx.ReadValue<Vector2>();
        }

        private void OnPerformActionPerformed (InputAction.CallbackContext ctx)
        {
            _isLeftMouseButtonPressed = true;
        }

        private void OnPerformActionCanceled (InputAction.CallbackContext ctx)
        {
            _isLeftMouseButtonPressed = false;
        }

        private void OnCancelActionPerformed (InputAction.CallbackContext ctx)
        {
            _isRightMouseButtonPressed = true;
        }

        private void OnCancelActionCanceled (InputAction.CallbackContext ctx)
        {
            _isRightMouseButtonPressed = false;
        }

        public bool IsMouseButtonPressed(MouseButton button)
        {
            return button == MouseButton.Left ? _isLeftMouseButtonPressed : _isRightMouseButtonPressed;
        }
    }

}

