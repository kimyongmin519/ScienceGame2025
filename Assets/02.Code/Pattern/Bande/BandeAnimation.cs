using System;
using UnityEngine;

public class BandeAnimation : MonoBehaviour
{
    private static int _attackReadyHash = Animator.StringToHash("AttackReady");
    private static int _rerollHash = Animator.StringToHash("Reroll");
    
    private Animator _animator;
    private BandeController _bandeController;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _bandeController = GetComponent<BandeController>();
    }

    private void Start()
    {
        _bandeController.OnReady += AttackReadyAnim;
        _bandeController.OnReroll += RerollAnim;
    }

    public void AttackReadyAnim()
    {
        _animator.SetTrigger(_attackReadyHash);
    }

    public void RerollAnim()
    {
        _animator.SetTrigger(_rerollHash);
    }

    private void OnDestroy()
    {
        _bandeController.OnReady -= AttackReadyAnim;
        _bandeController.OnReroll -= RerollAnim;
    }
}
