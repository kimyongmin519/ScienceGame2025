using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    
    public event Action OnStopPattern;
    public event Action OnStartPattern;
    
    private Camera _mainCamera;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        StartCoroutine(PatternRutine());
        StartCoroutine(BackgroundEffect());
    }

    private IEnumerator PatternRutine()
    {
        yield return new WaitForSeconds(90f);
        OnStopPattern?.Invoke();
        yield return new WaitForSeconds(28f);
        OnStartPattern?.Invoke();
        yield return new WaitForSeconds(77.456f);
        StartCoroutine(PatternRutine());
    }

    private IEnumerator BackgroundEffect()
    {
        ChangeBackground(new Color(43, 52, 70));
        yield return new WaitForSeconds(14f); // 14
        ChangeBackground(new Color(123, 23, 24));
        yield return new WaitForSeconds(14f); //28
        ChangeBackground(new Color(23, 81, 123));
        yield return new WaitForSeconds(30f); //58
        ChangeBackground(new Color(217, 19, 0));
        yield return new WaitForSeconds(32f); //90
        ChangeBackground(new Color(4, 94, 0));
        yield return new WaitForSeconds(14f); //104
        ChangeBackground(new Color(90, 94, 0));
        yield return new WaitForSeconds(15f); //119
        ChangeBackground(new Color( 43, 52, 70));
        yield return new WaitForSeconds(31f); //150
        ChangeBackground(new Color(217, 19, 0));
        yield return new WaitForSeconds(30f); //180
        ChangeBackground(new Color(0, 0, 0));
        yield return new WaitForSeconds(15.465f); //195.465
        StartCoroutine(BackgroundEffect());
    }

    public void ChangeBackground(Color color)
    {
        Color backColor = new Color(color.r / 255, color.g / 255, color.b / 255);
        
        _mainCamera.DOColor(backColor, 2f);
    }
}
