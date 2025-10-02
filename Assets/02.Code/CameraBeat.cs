using System;
using UnityEngine;
using UnityEngine.U2D;

public class CameraBeat : MonoBehaviour
{
    [SerializeField] private AudioSource bgmSource;

    private float[] spectrumData = new float[512];
    private float _baseLens;
    
    private Camera _camera;
    private PixelPerfectCamera _pixelPerfectCamera;

    private void Start()
    {
        if (Camera.main != null)
            _camera = Camera.main;
        
        _baseLens = _camera.orthographicSize;
        _pixelPerfectCamera = _camera.GetComponent<PixelPerfectCamera>();
    }

    private void Update()
    {
        bgmSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        float bass = 0f;

        for (int i = 0; i < 10; i++)
        {
            bass += spectrumData[i];
        }
        
        float intensity = Mathf.Clamp(bass * 100f, 0, 50f);
        
        float targetSize = _baseLens - (intensity / 15);
        
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, targetSize, 0.01f);
    }
}
