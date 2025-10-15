using UnityEngine;

public enum AnswerType
{
    O,
    X
}

[CreateAssetMenu(fileName = "QuizData", menuName = "SO/QuizData")]
public class QuizData : ScriptableObject
{
    public AnswerType answerType;
    public string question;
}