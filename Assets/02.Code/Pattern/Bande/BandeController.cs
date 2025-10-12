using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
using Sequence = DG.Tweening.Sequence;

public class BandeController : MonoBehaviour
{
    public event Action OnSpikeRush;

    public Action OnReady;
    public event Action OnReroll;

    [SerializeField] private Transform target;

    private void Start()
    {
        OnReady += Attack;
        
        Sequence s = DOTween.Sequence();

        s.AppendInterval(22f);
        s.Append(transform.DOMoveY(-4, 5f));
        s.Append(transform.DOMoveY(-8, 0.5f));
        s.AppendCallback(() =>

        {
            s.Append(transform.DOMoveY(1.5f, 0.75f)).SetEase(Ease.OutQuad);
            OnReroll?.Invoke();
        });

    }

    private void Update()
    {
        if (Keyboard.current.fKey.isPressed)
        {
            OnReady?.Invoke();
        }
    }

    private void Attack()
    {
        Sequence s = DOTween.Sequence();
        
        s.Append(transform.DOMoveX(target.transform.position.x, 0.5f)).SetEase(Ease.OutQuad);
    }

    private void OnDestroy()
    {
        OnReady -= Attack;
    }
}
