using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    [Header("Parameters")]
    public bool isDead = false;

    [Header("Refrences")]
    public GameObject deathScreen;
    public PlayerHealth pHealth;
    [SerializeField] private TextMeshProUGUI scoreNumber = default;
    public PlayerInventory pInventory;

    void Start()
    {
        deathScreen.SetActive(false);
    }

    private void Update()
    {
        scoreNumber.text = pInventory.score.ToString();
    }

    public void DeathScreenActivate()
    {
        Time.timeScale = 0;
        deathScreen.SetActive(true);
        isDead = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("The Village");
        Time.timeScale = 1;
    }
}
