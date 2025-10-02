using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    private AudioSource _audioSource;
    
    [Serializable]
    public struct ClipData
    {
        public string key;
        public AudioClip clip;
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlaySound(_audioSource);
    }


    public void PlaySound(AudioSource audioSource)
    {
        _audioSource.PlayOneShot(audioSource.clip);
    }
}
