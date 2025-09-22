using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, Context.IPlayerActions
{
    public Vector2 MoveDir { get; private set; }
    public void OnMove(InputAction.CallbackContext context)
    {
        
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
