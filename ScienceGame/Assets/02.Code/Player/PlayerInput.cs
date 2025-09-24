using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, Controller.IPlayerActions
{
    private Controller _controller;
    public Vector2 MoveDir { get; private set; }
    public event Action OnJumpPressed;

    private void OnEnable()
    {
        if (_controller == null)
        {
            _controller = new Controller();
            _controller.Player.SetCallbacks(this);
        }

        _controller.Player.Enable();
    }

    private void OnDisable()
    {
        _controller.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveDir = context.ReadValue<Vector2>().normalized;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        OnJumpPressed?.Invoke();
    }
}
