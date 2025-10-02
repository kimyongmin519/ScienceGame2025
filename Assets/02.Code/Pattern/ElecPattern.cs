using UnityEngine;

public abstract class ElecPattern
{
    [SerializeField] private ElecPatternSO elecPatternSO;
    public int elecNumber;
    public PatternType elecType;
    
    public ElecPattern(int elecId, PatternType type)
    {
        elecNumber = elecId;
        elecType = type;
    }
    
    public virtual void StartAttack()
    {
        
    }
}
