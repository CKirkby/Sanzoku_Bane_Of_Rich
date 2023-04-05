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

    private void OnEnable()
    {
        OnTakeDamage += ApplyDamage;
    }

    private void OnDisable()
    {
        OnTakeDamage -= ApplyDamage;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(float damage)
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
    {
        currentHealth = 0;

        if(regenerateHealth != null)
        {
            StopCoroutine(regenerateHealth);
        }

        Debug.Log("You are dead");
    }

    private IEnumerator RegenerateHealth()
    {
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