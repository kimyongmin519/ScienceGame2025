using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public GameObject titleImage;
    private void Start()
    {
        titleImage.SetActive(false);
    }
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void QuestionMark()
    {
        StartCoroutine(ActivateForSeconds());

    }
    private IEnumerator ActivateForSeconds()
    {
        // ������Ʈ �ѱ�
        titleImage.SetActive(true);
        

        // ���� �ð� ��ٸ���
        yield return new WaitForSeconds(0.2f);

        // ������Ʈ ����
        titleImage.SetActive(false);
        Debug.Log("������Ʈ ��Ȱ��ȭ��");
    }
}
