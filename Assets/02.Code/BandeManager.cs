using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BandeManager : MonoBehaviour
{
    private float _delay;
    [SerializeField] private float randomMin = 10f;
    [SerializeField] private float randomMax = 20f;
    
    private bool _patternEnabled = true;

    private Coroutine _pC;

    private void Start()
    {
        StartCoroutine(StartCorou());
        
        LevelManager.Instance.OnStopPattern +=  StopBande;
        LevelManager.Instance.OnStartPattern +=  StartBande;
    }

    private IEnumerator StartCorou()
    {
        yield return new WaitForSeconds(42.5f);
        BandeController.Instance.OnReady?.Invoke();
        _pC = StartCoroutine(PatternCorou());
    }

    private IEnumerator PatternCorou()
    {
        while (_patternEnabled)
        {
            _delay = Random.Range(randomMin, randomMax);
            yield return new WaitForSeconds(_delay);
            BandeController.Instance.OnReady?.Invoke();
            if (ScoreManager.Instance.Score > 1000)
            {
                randomMin = 7.5f;
                randomMax = 15f;
            }
            if (ScoreManager.Instance.Score > 3000)
            {
                randomMin = 5f;
                randomMax = 10f;
            }
        }
    }

    private void StopBande()
    {
        StopCoroutine(_pC);
        _patternEnabled = false;
        BandeController.Instance.Hide();
    }

    private void StartBande()
    {
        BandeController.Instance.BandeTurn();
        _patternEnabled = true;
        _pC = StartCoroutine(PatternCorou());
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnStopPattern -=  StopBande;
        LevelManager.Instance.OnStartPattern -=  StartBande;
    }
    
}
