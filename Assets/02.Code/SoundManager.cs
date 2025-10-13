using System;
using System.Collections;
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
        StartCoroutine(TtongCode());
    }


    public void PlaySound(AudioSource audioSource)
    {
        _audioSource.PlayOneShot(audioSource.clip);
    }

    private IEnumerator TtongCode()
    {
        PlaySound(_audioSource);
        yield return new WaitForSeconds(195.456f);
        StartCoroutine(TtongCode());
    }
}
