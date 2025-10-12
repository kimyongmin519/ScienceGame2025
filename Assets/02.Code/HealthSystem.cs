using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageable
{
    protected bool IsGod = false;
    
    private int _hp;
    public int Hp
    {
        get
        {
            return _hp;
        }
        set
        {
            int before = _hp;
            _hp = value;
            if (before != value)
            {
                OnHpChanged?.Invoke();
            }
        }
    }
    [field:SerializeField] public int MaxHp { get; private set; }

    protected event Action OnHpChanged;

    protected virtual void Start()
    {
        Hp = MaxHp;
        Debug.Log(Hp);
    }


    public void GetDamage(int damage)
    {
        if (!IsGod)
        {
            Hp -= damage;
            Debug.Log(Hp);
        }
    }
}
