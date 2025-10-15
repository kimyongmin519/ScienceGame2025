using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OX : MonoBehaviour
{
    public Image correctImage;
    public Image wrongImage;
    public TextMeshProUGUI questionText;
    int currentQuizIndex = 0;
    bool OAnswer = false;
    bool XAnswer = false;
    private void Awake()
    {
        correctImage.gameObject.SetActive(false);
        wrongImage.gameObject.SetActive(false);
    }
    private void Start()
    {
       currentQuizIndex =  Random.Range(0,6);
    }
    private void Update()
    {
        switch (currentQuizIndex)
        {
            case 0:
                questionText.text = "전하의 갯수를 나타내는 단위는 쿨롱[K]이다.";
                
                XCorrect();
                break;
            case 1:
                questionText.text = "두 점 사이의 전위의 차이를 전위라고 한다.";
                
                XCorrect();
                break;
            case 2:
                questionText.text = "전기장 내에서 단위 양(+)전하가 가지는 전기적 위치 에너지를 전압이라고 한다.";
                
                XCorrect();
                break;
            case 3:
                questionText.text = "두 전하 사이의 거리가 r일 때 작용하는 전기력의 크기는 5r일때 작용하는 전기력의 크기의 25배이다.";
                
                OCorrect();
                break;
            case 4:
                questionText.text = "전기장은 단위 양(+)전하에 작용하는 전기력의 크기를 의미한다.";
                
                OCorrect(); 
                break;
            case 5:
                questionText.text = "중성인 두 물체를 마찰하면 음(-)전하가 이동하여 물체는 각각 전기적 성질을 띤다.";
                
                OCorrect();
                break;
        }
    }
    public void OButton()
    {
        Debug.Log("OButton");
        OAnswer = true;
    }
    public void XButton()
    {
        Debug.Log("XButton");
        XAnswer = true;
    }
    public void OXButtonSet()
    {
        XAnswer = false;
        OAnswer = false;
    }
    public void OCorrect()
    {
        if (OAnswer)
        {
           Correct();

        }
        else if (XAnswer)
        {
           Wrong();

        }
    }
    public void XCorrect()
    {
        if (XAnswer)
        {
            Debug.Log("Correct");
            Correct();
            
        }
        else if (OAnswer)
        {
           Wrong();
        }
    }
    public void Correct()
    {
        correctImage.gameObject.SetActive(true);
    }
    public void Wrong()
    {
        wrongImage.gameObject.SetActive(true);

    }
    public void Replay()
    {
        correctImage.gameObject.SetActive(false);
        wrongImage.gameObject.SetActive(false);
        currentQuizIndex = Random.Range(0, 6);
        OXButtonSet();
    }
    public void NextScene()
    {
        Debug.Log("NextScene");
        
    }
}
