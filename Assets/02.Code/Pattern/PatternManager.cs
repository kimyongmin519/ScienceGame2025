using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatternManager : MonoBehaviour
{
    [SerializeField] private ElecPatternSO[] elecPatterns;

    private float _delay = 1f;
    [SerializeField]
    public float Delay
    {
        get
        {
            return _delay;
        }
        set
        {
            _delay = Mathf.Clamp(value, 0.275f, 1f);
        }
    }

    private bool _patternEnabled = true;

    private Coroutine _pC;
    private Coroutine _pC2;
    

    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        ElectronicController.Instance.HitboxSpawn(Vector3.right * 100);
        _pC = StartCoroutine(TestCour());
        _pC2 = StartCoroutine(DifiUpCoroutine());
        
        LevelManager.Instance.OnStopPattern += StopElectronic;
        LevelManager.Instance.OnStartPattern += StartElectronic;
    }

    IEnumerator TestCour()
    {
        while (_patternEnabled)
        {
            ElectronicController.Instance.HitboxSpawn(spawnPoints[Random.Range(0, spawnPoints.Length)].position);
            yield return new WaitForSeconds(Delay);
            
        } 
    }

    IEnumerator DifiUpCoroutine()
    {
        while (_patternEnabled)
        {
            yield return new WaitForSeconds(1);
            Delay -= 0.0025f;
        } 
    }

    private void StopElectronic()
    {
        StopCoroutine(_pC);
        StopCoroutine(_pC2);
        _patternEnabled = false;
    }

    private void StartElectronic()
    {
        _patternEnabled = true;
        _pC = StartCoroutine(TestCour());
        _pC2 = StartCoroutine(DifiUpCoroutine());
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnStopPattern -= StopElectronic;
        LevelManager.Instance.OnStartPattern -= StartElectronic;
    }
}
