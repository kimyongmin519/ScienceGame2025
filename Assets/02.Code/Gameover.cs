using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        text.SetText($"최종 점수:{ScoreManager.Instance.Score.ToString()}");
    }

    public void GoTitleScene()
    {
        SceneManager.LoadScene("Title");
    }
}
