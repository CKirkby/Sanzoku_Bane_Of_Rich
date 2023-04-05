using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Image healthBar = default;
    [SerializeField] private TextMeshProUGUI scoreNumber = default;
    public PlayerInventory pInventory;
    public PlayerHealth pHealth;

    /*
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
    */

    private void Start()
    {
        UpdateHeath();
    }

    private void Update()
    {
        scoreNumber.text = pInventory.score.ToString();
        UpdateHeath();
    }

    private void UpdateHeath()
    {
        healthBar.fillAmount = pHealth.currentHealth / 100;
    }
}
