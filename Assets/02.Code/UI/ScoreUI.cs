using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        _scoreText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        ScoreManager.Instance.OnScoreChanged += UiChange;
    }

    private void UiChange(int score)
    {
        _scoreText.SetText($"점수:{score.ToString()}");
    }
}
