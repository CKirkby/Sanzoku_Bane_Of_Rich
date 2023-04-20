using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider volSlider;
    public AudioManager audioManager;

    public void PlayGame()
    {
        //When pressed play, will load next scene. 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ChangeVolume()
    {
        //Connects the UI slider to the audio source volume allowing control. 
        audioManager.m_AudioSource.volume = volSlider.value;
    }

}
