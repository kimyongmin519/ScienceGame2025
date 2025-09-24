using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Player _player;
    private Animator _animator;
    
    private int _moveHash = Animator.StringToHash("MoveX");
    private int _groundHash = Animator.StringToHash("IsGround");

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetAnimation();
    }

    private void SetAnimation()
    {
        _animator.SetFloat(_moveHash, Mathf.Abs(_player.MoveCompo.RbCompo.linearVelocityX));
    }
    
}
