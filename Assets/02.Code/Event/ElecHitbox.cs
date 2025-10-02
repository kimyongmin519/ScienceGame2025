using System;
using _02.Code.Pooling;
using UnityEngine;
using DG.Tweening;

public class ElecHitbox : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private PoolFactory<ElecHitbox> _pool;
    public float Delay { get; set; }

    public void Initialize(PoolFactory<ElecHitbox> pool) => _pool = pool;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(_spriteRenderer.DOFade(0.5f, Delay));
        seq.Join(transform.DOScaleX(1.5f, Delay));
        seq.AppendCallback(() => _pool.Push(this));
    }

    private void OnDisable()
    {
        _spriteRenderer.DOFade(0f, 0f);
        transform.DOScaleX(0.1f, 0f);
    }
}
