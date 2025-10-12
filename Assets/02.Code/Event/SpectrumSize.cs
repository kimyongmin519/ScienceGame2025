using UnityEngine;

public class SpectrumSize : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public float sensitivity = 20f;
    public float smoothSpeed = 5f;
    public int startFrequency = 200;

    private float[] spectrum = new float[512];
    private Vector3 originalScale;
    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        float pitchEnergy = 0f;
        int count = 0;

        for (int i = startFrequency; i < spectrum.Length; i++)
        {
            pitchEnergy += spectrum[i];
            count++;
        }

        pitchEnergy = (count > 0) ? pitchEnergy / count : 0f;
        pitchEnergy *= sensitivity;

        float scaleX = Mathf.Lerp(transform.localScale.x, originalScale.x + pitchEnergy, Time.deltaTime * smoothSpeed);
        float scaleY = Mathf.Lerp(transform.localScale.y, originalScale.y + pitchEnergy, Time.deltaTime * smoothSpeed);

        transform.localScale = new Vector3(scaleX, scaleY, originalScale.z);
    }
}