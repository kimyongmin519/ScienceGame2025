using _02.Code.Player;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour, IPlayerComponent
{
    public Rigidbody2D RbCompo { get; private set; }
    private Player _player;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 groundCheckerSize;

    public UnityEvent<float,float> OnMovement;
    
    public bool IsGrounded { get; private set; }

    private float _timeInAir;
    private float _extraGravity = 0.275f;

    private void Update()
    {
        IsGrounded = Physics2D.OverlapBox(transform.position, groundCheckerSize, 0, groundLayer);

        if (!IsGrounded)
            _timeInAir += Time.deltaTime;
        else
            _timeInAir = 0;
        
        if (_timeInAir > _extraGravity)
        {
            ExtraGravity();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, groundCheckerSize);
    }
    private void FixedUpdate()
    {
        Xmove(_player.InputCompo.MoveDir.x, _player.PlayerData.PlayerSpeed);
    }
    public void Xmove(float moveDir, float speed)
    {
        RbCompo.linearVelocityX = moveDir * speed;
        OnMovement?.Invoke(moveDir, RbCompo.linearVelocityY);
    }

    public void Jump()
    {
        if (!IsGrounded) return;
        RbCompo.linearVelocityY = 0;
        RbCompo.AddForceY(_player.PlayerData.PlayerJumpPower, ForceMode2D.Impulse);
    }

    public void Initialize(Player player)
    {
        RbCompo = player.GetComponent<Rigidbody2D>();
        _player = player;
        _player.InputCompo.OnJumpPressed += Jump;
    }

    private void ExtraGravity()
    {
        RbCompo.AddForce(Vector2.down * 0.1f, ForceMode2D.Impulse);
    }

    private void OnDestroy()
    {
        _player.InputCompo.OnJumpPressed -= Jump;
    }
}