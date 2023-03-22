using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthNumber = default;
    [SerializeField] private TextMeshProUGUI scoreNumber = default;

    public PlayerInventory inventory;

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
        UpdateScore(0);
    }

    private void UpdateHeath(float currentHealth)
    {
        healthNumber.text = currentHealth.ToString("00");
    }

    private void UpdateScore(float currentScore)
    {
        currentScore = inventory.score;
        scoreNumber.text = currentScore.ToString("00");
    }
}
