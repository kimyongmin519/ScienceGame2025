using System;
using _02.Code.Pooling;
using UnityEngine;
using DG.Tweening;

public class Electronic : MonoBehaviour
{
    [SerializeField] private float delay = 1f;
    [SerializeField] private float range = 1.5f;
    [SerializeField] private int damage = 1;
    
    [SerializeField] private GameObject pillar;
    [SerializeField] private SpriteRenderer elecEffect;
    
    private AudioSource _audioSource;

    private PoolFactory<Electronic> _pool;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PlayEffect();
    }

    public void Initialize(PoolFactory<Electronic> pool) => _pool = pool;

    public void PlayEffect()
    {
        
        Sequence sequence = DOTween.Sequence();
        
        HitScan();
        SoundManager.Instance.PlaySound(_audioSource);

        sequence.Append(pillar.transform.DOScaleX(range, 0.15f).SetEase(Ease.OutBack));
        sequence.AppendInterval(0.05f);
        sequence.Append(pillar.transform.DOScaleX(0, 0.35f).SetEase(Ease.InBounce));
        sequence.AppendCallback(() =>
        {
            _pool.Push(this);
        });
    }

    public void HitScan()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, new Vector2(1.5f, 20f), 0);
        if (collider != null)
        {
            if (collider.TryGetComponent<Player>(out Player player))
            {
                player.GetDamage(damage);
                Debug.Log(player.HP);
            }
        }
    }
    
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(1.5f, 20f));
    }
}