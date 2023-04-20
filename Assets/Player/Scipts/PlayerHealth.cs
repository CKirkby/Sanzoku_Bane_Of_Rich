using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Parameters")]
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float timeForRegenStart = 3;
    [SerializeField] private float healthValueIncrement = 1;
    [SerializeField] private float healthTimeIncrement = 0.1f;
    public float currentHealth;
    private Coroutine regenerateHealth;
    public static Action<float> OnTakeDamage;
    public static Action<float> OnDamage;
    public static Action<float> OnHeal;

    public DeathMenu dMenu;

    private void OnEnable()
    {
        OnTakeDamage += ApplyDamage;
    }

    private void OnDisable()
    {
        OnTakeDamage -= ApplyDamage;
    }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(float damage)
        //When damage is applied, if not dead, will start coroutine to regen health. 
    {
        currentHealth -= damage;
        OnDamage?.Invoke(currentHealth);

        if(currentHealth < 0)
        {
            killPlayer();
        }
        else if(regenerateHealth != null)
        {
            StopCoroutine(regenerateHealth);
        }

        regenerateHealth = StartCoroutine(RegenerateHealth());
    }

    public void killPlayer()
        //If hp is 0 will stop regen health and activate the UI death screen.
    {
        currentHealth = 0;

        if(regenerateHealth != null)
        {
            StopCoroutine(regenerateHealth);
            dMenu.DeathScreenActivate();
        }
    }

    private IEnumerator RegenerateHealth()
    {
        //Detects when hp is less then max health and creates an waitforseconds to increase health by the determined increment of time i.e. every 0.1 of a second. 

        yield return new WaitForSeconds(timeForRegenStart);

        WaitForSeconds timeToWait = new WaitForSeconds(healthTimeIncrement);

        while(currentHealth < maxHealth)
        {
            currentHealth += healthValueIncrement;

            if(currentHealth > maxHealth)
                currentHealth = maxHealth;

            OnHeal?.Invoke(currentHealth);
            yield return timeToWait;
        }

        regenerateHealth = null;

    }
}