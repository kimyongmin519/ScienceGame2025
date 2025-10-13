using UnityEngine;
using DG.Tweening;

public class BandeHitBox : MonoBehaviour
{
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Sequence s = DOTween.Sequence();
        
        s.Append(_renderer.DOFade(0.6f, 1.85f));
        s.AppendCallback(() => Destroy(gameObject));
    }
}
