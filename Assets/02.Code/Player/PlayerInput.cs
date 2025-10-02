using System;
using _02.Code.Player;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInput", menuName = "SO/PlayerInput")]
public class PlayerInput : ScriptableObject, Controller.IPlayerActions
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
        MoveDir = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnJumpPressed?.Invoke();
    }
}