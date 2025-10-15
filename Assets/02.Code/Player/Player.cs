using System.Linq;
using _02.Code.Player;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Sequence = DG.Tweening.Sequence;

public class Player : HealthSystem
{
    [SerializeField] private float shieldDuration = 3f;
    [field: SerializeField] public PlayerSO PlayerData {  get; private set; }
    [field: SerializeField] public PlayerInput InputCompo { get; private set; }

    [SerializeField] private Transform shield;
    private bool _inHit = false;

    public UnityEvent OnHairUp;
    

    private void Awake()
    {
        GetComponentsInChildren<IPlayerComponent>().ToList().ForEach(compo => compo.Initialize(this));
    }

    protected override void Start()
    {
        base.Start();
        OnHpChanged += ShowShield;
        OnDeath += Dead;
    }

    private void Update()
    {
        FilpX();

        if (_inHit)
            OnHairUp?.Invoke();

        _inHit = false;
    }

    private void FilpX()
    {
        if (InputCompo.MoveDir.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (InputCompo.MoveDir.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent<ElecHitbox>(out ElecHitbox elecHitbox))
            _inHit = true;
    }

    public void ShowShield()
    {
        Sequence s = DOTween.Sequence();
        
        IsGod = true;
        shield.gameObject.SetActive(true);
        s.Append(shield.DOScale(new Vector3(1.75f, 1.75f, 1f), 0.25f)).SetEase(Ease.OutQuad);
        s.Append(shield.DOScale(new Vector3(1.5f, 1.5f, 1f), 0.5f)).SetEase(Ease.OutQuad);
        s.AppendInterval(shieldDuration);
        s.Append(shield.DOScale(new Vector3(0.1f, 0.1f, 1f), 0.25f)).SetEase(Ease.OutQuad);
        s.AppendCallback(() =>
        {
            shield.gameObject.SetActive(false);
            IsGod = false;
        });
    }


    private void OnDestroy()
    {
        OnHpChanged -= ShowShield;
        OnDeath -= Dead;
    }

    private void Dead()
    {
        SceneManager.LoadScene("Gameover");
    }
}