using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int _score;

    public int Score
    {
        get => _score;
        set
        {
            int before = _score;
            _score = value;

            if (before != value)
                OnScoreChanged?.Invoke(value);
            
            _score = Mathf.Clamp(value, 0, int.MaxValue);
        }
    }

    public Action<int> OnScoreChanged;
    public Action<int> OnScoreDrop;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        OnScoreDrop += ScoreUp;
    }

    private void ScoreUp(int score)
    {
        Score += score;
    }

    private void OnDestroy()
    {
        OnScoreDrop -= ScoreUp;
    }
}
