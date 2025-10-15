using _02.Code.Pooling;
using UnityEngine;
using DG.Tweening;

public class Electronic : MonoBehaviour
{
    [SerializeField] private float delay = 1f;
    [SerializeField] private float range = 1.5f;

    [SerializeField] private GameObject pillar;
    [SerializeField] private SpriteRenderer elecEffect;

    private AudioSource _audioSource;

    private PoolFactory<Electronic> _pool;

    private Vector2 elecRange = new Vector2(1.5f, 20f);

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
        SoundManager.Instance.PlaySound(_audioSource);

        sequence.Append(pillar.transform.DOScaleX(range, 0.1f).SetEase(Ease.OutBack));
        sequence.AppendInterval(0.035f);
        sequence.Append(pillar.transform.DOScaleX(0, 0.25f).SetEase(Ease.InBounce));
        sequence.AppendCallback(() => { _pool.Push(this); });
    }

    private bool tung = false;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, elecRange);
    }
}
    
