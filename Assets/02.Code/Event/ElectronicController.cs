using System.Collections;
using _02.Code.Pooling;
using DG.Tweening;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

public class ElectronicController : MonoBehaviour
{
    public static ElectronicController Instance;
    
    [SerializeField] private ScoreValueSO scoreValueData;
    
    [SerializeField] private Electronic elecPrefab;
    [SerializeField] private ElecHitbox hitboxPrefab;
    [SerializeField] private float attackDelay = 1f;
    [SerializeField] private int damage = 1;

    private PoolFactory<Electronic> _elecFactory;
    private PoolFactory<ElecHitbox> _hitboxFactory;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        _elecFactory = new PoolFactory<Electronic>(elecPrefab);
        _hitboxFactory = new PoolFactory<ElecHitbox>(hitboxPrefab);
    }

    public void HitboxSpawn(Vector3 spawnPos)
    {
        ElecHitbox hitbox = _hitboxFactory.Pop();
        hitbox.Delay = attackDelay;
        hitbox.Initialize(_hitboxFactory);
        hitbox.transform.parent = transform.parent;
        hitbox.transform.position = spawnPos;
        hitbox.transform.localScale = new Vector3(0.1f,20,1);
        
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(attackDelay);
        sequence.AppendCallback(() =>
        {
            HitScan(spawnPos);
            ElecSpawn(spawnPos);
        });
    }

    private void ElecSpawn(Vector3 spawnPos)
    {
        ScoreManager.Instance.OnScoreDrop?.Invoke(scoreValueData.elecScore);
        
        Electronic elec = _elecFactory.Pop();
        elec.Initialize(_elecFactory);
        elec.transform.parent = transform.parent;
        elec.transform.position = spawnPos;
        elec.transform.localScale = new Vector3(1,20,1);
        StartCoroutine(HitPanjeon(spawnPos));
        
    }
    
    private Vector2 _elecRange = new Vector2(1.5f, 20);
    private void HitScan(Vector3 spawnPos)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(spawnPos, _elecRange, 0);

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent<Player>(out Player player))
            {
                player.GetDamage(damage);
            }
        }
    }

    IEnumerator HitPanjeon(Vector3 spawnPos)
    {
        for (int i = 0; i < 50; i++)
        {
            HitScan(spawnPos);
            yield return null;
        }
    }
}
