using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    
    public event Action OnStopPattern;
    public event Action OnStartPattern;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(PatternRutine());
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
}
