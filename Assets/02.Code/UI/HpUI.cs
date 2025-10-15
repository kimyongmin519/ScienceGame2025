using System;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private GameObject heart;
    
    private GameObject[] hearts;

    private void Awake()
    {
        hearts = new GameObject[healthSystem.MaxHp];
        
        for (int i = 0; i < healthSystem.MaxHp; i++)
        {
            GameObject h = Instantiate(heart, transform);
            hearts[i] = h;
        }

        healthSystem.OnHpChanged += SetHpUI;
        
    }

    private void SetHpUI()
    {
        for (int i = 0; i < healthSystem.MaxHp; i++)
            hearts[i].GetComponent<Image>().color = Color.clear;
        for (int i = 0; i < healthSystem.Hp; i++)
            hearts[healthSystem.MaxHp - 1 - i].GetComponent<Image>().color = Color.white;
    }

    private void OnDestroy()
    {
        healthSystem.OnHpChanged -= SetHpUI;
    }
}
