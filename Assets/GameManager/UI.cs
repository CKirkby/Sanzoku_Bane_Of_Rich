using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class UI : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private TextMeshProUGUI healthNumber = default;
    [SerializeField] private TextMeshProUGUI scoreNumber = default;
    public PlayerInventory pInventory;

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

    private void Update()
    {
        scoreNumber.text = pInventory.score.ToString();
    }

    private void UpdateHeath(float currentHealth)
    {
        healthNumber.text = currentHealth.ToString("00");
    }
}
