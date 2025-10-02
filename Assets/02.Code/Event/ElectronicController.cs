using System;
using _02.Code.Pooling;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class ElectronicController : MonoBehaviour
{
    public static ElectronicController Instance;
    
    [SerializeField] private Electronic elecPrefab;
    [SerializeField] private ElecHitbox hitboxPrefab;
    [SerializeField] private float attackDelay = 1f;

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
        hitbox.Initialize(_hitboxFactory);
        hitbox.transform.parent = transform.parent;
        hitbox.transform.position = spawnPos;
        hitbox.Delay = attackDelay;
        hitbox.transform.localScale = new Vector3(0.1f,20,0);
        
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(attackDelay);
        sequence.AppendCallback(() => ElecSpawn(spawnPos));
    }

    private void ElecSpawn(Vector3 spawnPos)
    {
        Electronic elec = _elecFactory.Pop();
        elec.Initialize(_elecFactory);
        elec.transform.parent = transform.parent;
        elec.transform.position = spawnPos;
        elec.transform.localScale = new Vector3(1,20,0);
    }
}
