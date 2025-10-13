using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
using Sequence = DG.Tweening.Sequence;

public class BandeController : MonoBehaviour
{
    public static BandeController Instance { get; private set; }
    public event Action OnExpolotion;

    public Action OnReady;
    public event Action OnReroll;

    [SerializeField] private Transform target;
    [Header("프리팹")]
    [SerializeField] private GameObject hitbox;
    [SerializeField] private GameObject expolotionEffect;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        OnReady += BandeMove;
        OnReady += ShowHitbox;
        
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

    private void BandeMove()
    {
        Sequence s = DOTween.Sequence();
        
        s.Append(transform.DOMoveX(target.transform.position.x, 0.5f)).SetEase(Ease.OutQuad);
    }

    public void Charge()
    {
        transform.DOMoveY(1, 0.75f).SetRelative(true).SetEase(Ease.OutQuad);
    }

    public void Attack()
    {
        Sequence s = DOTween.Sequence();
        
        s.Append(transform.DOMoveY(-5, 0.2f)).SetRelative(true).SetEase(Ease.OutQuad);
        s.AppendCallback(() =>
        {
            OnExpolotion?.Invoke();
            Instantiate(expolotionEffect, new Vector3(transform.position.x, -2.3f,0), Quaternion.identity);
        });
    }

    private void OnDestroy()
    {
        OnReady -= BandeMove;
        OnReady -= ShowHitbox;
    }

    public void BandeTurn()
    {
        transform.DOMove(new Vector3(0, 1.5f, 0), 0.75f).SetEase(Ease.OutQuad);
    }

    private void ShowHitbox()
    {
        Instantiate(hitbox, target.position, Quaternion.identity);
    }

    public void Hide()
    {
        transform.DOMoveY(-8, 1.5f).SetEase(Ease.OutQuad);
    }
}
