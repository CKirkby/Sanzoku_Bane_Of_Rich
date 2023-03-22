using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText = default;

    private void OnEnable()
    {
        PlayerHealth.OnDamage += UpdateHeath;
        PlayerHealth.OnHeal += UpdateHeath;
    }

    private void OnDisable()
    {
        PlayerHealth.OnDamage -= UpdateHeath;
        PlayerHealth.OnHeal -= UpdateHeath;

    }

    private void Start()
    {
        UpdateHeath(100);
    }

    private void UpdateHeath(float currentHealth)
    {
        healthText.text = currentHealth.ToString("00");
    }
}
