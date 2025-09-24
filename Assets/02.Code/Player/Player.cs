using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    
    public PlayerInput InputCompo { get; private set; }
    public PlayerMovemant MoveCompo { get; private set; }

    private void Awake()
    {
        InputCompo = GetComponent<PlayerInput>();
        MoveCompo = GetComponent<PlayerMovemant>();
    }

    private void FixedUpdate()
    {
        MoveCompo.Xmove(InputCompo.MoveDir.x, playerSO.PlayerSpeed);
    }

    private void Update()
    {
        FilpX();
    }

    public void FilpX()
    {
        if (InputCompo.MoveDir.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if  (InputCompo.MoveDir.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
