using System;
using UnityEngine;

public class PlayerMovemant : MonoBehaviour
{
    public Rigidbody2D RbCompo { get; private set; }

    private void Awake()
    {
        RbCompo = GetComponent<Rigidbody2D>();
    }

    public void Xmove(float moveDir, float speed)
    {
        RbCompo.linearVelocityX = moveDir * speed;
    }
}
