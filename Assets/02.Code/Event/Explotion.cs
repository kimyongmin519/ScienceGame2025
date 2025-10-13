using System;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    [SerializeField] private Vector2 size;
    [SerializeField] private int damage;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.time = 0.55f;
        SoundManager.Instance.PlaySound(_audioSource);
        
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, size,0);
        foreach (Collider2D c in colliders)
        {
            if (c.TryGetComponent(out Player player))
            {
                player.GetDamage(damage);
            }
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
