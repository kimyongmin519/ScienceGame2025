using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class QuizSystem : MonoBehaviour
{
    [SerializeField] private ScoreValueSO scoreValueSO;
    
    [SerializeField] private QuizData[] datas;
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource _audioSource;

    private RectTransform _rectTransform;

    private TextMeshProUGUI _text;
    private AnswerType _currentAnswer =  AnswerType.O;

    private int beforeIndex;
    private int _quizIndex = 0;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _rectTransform = GetComponent<RectTransform>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        LevelManager.Instance.OnStopPattern += Show;
        LevelManager.Instance.OnStartPattern += Hide;
    }

    private void OnEnable()
    {
        SetQuiz();
    }

    public void SetQuiz()
    {
        do
        {
            _quizIndex = Random.Range(0, datas.Length);
            Debug.Log(_quizIndex);
        } while (_quizIndex == beforeIndex);
            
        _text.SetText(datas[_quizIndex].question);
        _currentAnswer = datas[_quizIndex].answerType;
    }

    public void O()
    {
        Pan(AnswerType.O);
        SetQuiz();
    }
    
    public void X()
    {
        Pan(AnswerType.X);
        SetQuiz();
    }

    private void Pan(AnswerType answerType)
    {
        if (_currentAnswer == answerType)
        {
            ScoreManager.Instance.OnScoreDrop(scoreValueSO.quScore);
            _audioSource.time = 0;
            _audioSource.clip = audioClips[0];
            SoundManager.Instance.PlaySound(_audioSource);
        }
        else
        {
            ScoreManager.Instance.OnScoreDrop(-2 * (scoreValueSO.quScore));
            _audioSource.time = 0.7f;
            _audioSource.clip = audioClips[1];
            SoundManager.Instance.PlaySound(_audioSource);
        }
    }

    private void Show()
    {
        _rectTransform.DOAnchorPosY(0, 0.75f);
    }

    private void Hide()
    {
        _rectTransform.DOAnchorPosY(500, 0.75f);
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnStopPattern -= Show;
        LevelManager.Instance.OnStartPattern -= Hide;
    }
}
