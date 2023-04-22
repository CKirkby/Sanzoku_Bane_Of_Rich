using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinGameMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winNumver = default;
    public PlayerInventory pInventory;
    public GameObject winScreen;

    void Start()
    {
        winScreen.SetActive(false);
    }

    void Update()
    {
        winNumver.text = pInventory.score.ToString();
        Win();
    }

    private void Win()
    {
        //If the player gets the required score , activates the win screen.
        if(pInventory.score >= 5000)
        {
            winScreen.SetActive(true);
        }
    }
}
