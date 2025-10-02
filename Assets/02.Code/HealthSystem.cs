using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageable
{
    public int HP { get; private set; }
    [field:SerializeField] public int MaxHP { get; private set; }

    private void Start()
    {
        HP = MaxHP;
        Debug.Log(HP);
    }


    public void GetDamage(int damage)
    {
        HP -= damage;
    }
}
