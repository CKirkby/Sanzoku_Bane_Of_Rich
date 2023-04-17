using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image loadingBar;

    public bool isLoading = true;

    private void Start()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(TimeToLoad());
    }

    private void Update()
    {
        LoadingBar();
    }

    IEnumerator TimeToLoad()
    {
        yield return new WaitForSeconds(4);

        loadingScreen.SetActive(false);
        isLoading = false;
    }

    private void LoadingBar()
    {
        loadingBar.fillAmount += 0.25f * Time.deltaTime;
    }
}
