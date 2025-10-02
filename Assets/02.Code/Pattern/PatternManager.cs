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
            _delay = Mathf.Clamp(value, 0.2f, 1f);
        }
    }

    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        ElectronicController.Instance.HitboxSpawn(Vector3.right * 100);
        StartCoroutine(TestCour());
        StartCoroutine(DifiUpCoroutine());
    }

    IEnumerator TestCour()
    {
        ElectronicController.Instance.HitboxSpawn(spawnPoints[Random.Range(0, spawnPoints.Length)].position);
        yield return new WaitForSeconds(Delay);
        StartCoroutine(TestCour());
    }

    IEnumerator DifiUpCoroutine()
    {
        yield return new WaitForSeconds(1);
        Delay -= 0.005f;
        StartCoroutine(DifiUpCoroutine());
    }
}
