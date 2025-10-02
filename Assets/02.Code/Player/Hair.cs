using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hair : MonoBehaviour
{
    private Animator _animator;
    private static readonly int HairFocus = Animator.StringToHash("Focus");

    private float excitementValue = 0f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        excitementValue -= Time.deltaTime;
        if (0.99f < excitementValue)
            HairMove(true);
        else
            HairMove(false);
    }

    public void HairMove(bool b)
    {
        _animator.SetBool(HairFocus, b);
    }

    public void HighEx()
    {
        excitementValue = 1f;
    }
}
