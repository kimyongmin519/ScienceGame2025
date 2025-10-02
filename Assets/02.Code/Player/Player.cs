using System.Linq;
using _02.Code.Player;
using UnityEngine;
using UnityEngine.Events;

public class Player : HealthSystem
{
    [field: SerializeField] public PlayerSO PlayerData {  get; private set; }
    [field: SerializeField] public PlayerInput InputCompo { get; private set; }
    private bool _inHit = false;

    public UnityEvent OnHairUp;
    

    private void Awake()
    {
        GetComponentsInChildren<IPlayerComponent>().ToList().ForEach(compo => compo.Initialize(this));
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
}