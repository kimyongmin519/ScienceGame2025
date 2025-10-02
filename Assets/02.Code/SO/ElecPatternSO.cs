using UnityEngine;

public enum PatternType
{
    Straight,
    Random,
    DoubleStraight,
    EzSunda
}

[CreateAssetMenu(fileName = "ElecPatterm", menuName = "SO/ElecPatterm")]
public class ElecPatternSO : ScriptableObject
{
    public PatternType elecPattern;
    public int elecNumber;
}
