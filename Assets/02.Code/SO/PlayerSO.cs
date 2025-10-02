using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "SO/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public int PlayerHP;
    public float PlayerSpeed;
    public float PlayerJumpPower;
}
