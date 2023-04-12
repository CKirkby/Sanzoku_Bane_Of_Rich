using JetBrains.Annotations;
using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    public PirateFOV enemyFOV;
    public PirateStateMachine enemyStateMach;

    [Header("Stealth Detection")]
    [SerializeField] private Image eyeClosed;
    [SerializeField] private Image eyeHalf;
    [SerializeField] private Image eyeOpen;

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
        StealthDetection();
    }

    private void UpdateHeath()
    {
        healthBar.fillAmount = pHealth.currentHealth / 100;
    }

    public void StealthDetection()
    {
        if(enemyFOV.detectionPoints <= 0)
        {
            eyeClosed.enabled = true;
            eyeHalf.enabled = false;
            eyeOpen.enabled = false;
        }

        if(enemyFOV.detectionPoints > 0)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = true;
            eyeOpen.enabled = false;
        }

        if(enemyFOV.detectionPoints >= 300)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = false;
            eyeOpen.enabled = true;
        }

        if (enemyFOV.detectionPoints < 300 && enemyStateMach.hasLostPlayer == true)
        {
            eyeClosed.enabled = false;
            eyeHalf.enabled = true;
            eyeOpen.enabled = false;
        }
    }
}
