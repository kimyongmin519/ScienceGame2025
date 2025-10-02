using System;
using DG.Tweening;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Player _player;
    private Animator _animator;

    [SerializeField] private Hair hair;

    private static readonly int MoveHash = Animator.StringToHash("MoveX");
    private static readonly int HeightHash = Animator.StringToHash("MoveY");
    private static readonly int GroundedHash = Animator.StringToHash("IsGround");

    private PlayerMovement _playerMovement;

    private Vector3 _firstPos;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        _animator = GetComponent<Animator>();
        _playerMovement = _player.GetComponentInChildren<PlayerMovement>();

        _firstPos = transform.localPosition + new Vector3(0, 0.3f, 0);
    }
    
    public void SetAnimation(float moveX, float moveY)
    {
        _animator.SetFloat(MoveHash, Mathf.Abs(moveX));
        _animator.SetFloat(HeightHash, moveY);
        _animator.SetBool(GroundedHash, _playerMovement.IsGrounded);
    }

    public void HairLow()
    {
        hair.transform.localPosition -= Vector3.up * 0.075f;
    }
    
    public void HairHigh()
    {
        hair.transform.localPosition = _firstPos;
    }
}