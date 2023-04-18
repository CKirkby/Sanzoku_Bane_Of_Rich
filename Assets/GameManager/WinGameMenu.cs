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

    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        winNumver.text = pInventory.score.ToString();
        Win();
    }

    private void Win()
    {
        if(pInventory.score >= 500)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
