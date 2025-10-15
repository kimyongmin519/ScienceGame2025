using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        
        DontDestroyOnLoad(gameObject);

        OnScoreDrop += ScoreUp;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void ScoreUp(int score)
    {
        Score += score;
    }

    private void OnDestroy()
    {
        OnScoreDrop -= ScoreUp;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Gameover")
            _score = 0;
    }
}
