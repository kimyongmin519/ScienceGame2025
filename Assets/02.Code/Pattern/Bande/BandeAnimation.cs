using System;
using UnityEngine;

public class BandeAnimation : MonoBehaviour
{
    private static readonly int attackReadyHash = Animator.StringToHash("AttackReady");
    private static readonly int rerollHash = Animator.StringToHash("Reroll");
    
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

    private void AttackReadyAnim()
    {
        _animator.SetTrigger(attackReadyHash);
    }

    private void RerollAnim()
    {
        _animator.SetTrigger(rerollHash);
    }

    public void ResetReadyAnim()
    {
        _animator.ResetTrigger(attackReadyHash);
        _bandeController.BandeTurn();
    }

    private void OnDestroy()
    {
        _bandeController.OnReady -= AttackReadyAnim;
        _bandeController.OnReroll -= RerollAnim;
    }
}
