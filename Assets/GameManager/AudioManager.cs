using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Function Parameters")]
    [SerializeField] private bool useAmbiance = true;

    [Header("Audio Parameters")]
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioClip attackClip;

    [Header("Refrences")]
    [SerializeField] private PirateFOV pFOV;

    void Start()
    {
        if (useAmbiance)
        {
            Ambiance();
            m_AudioSource.loop = true;
        }
    }

    void Update()
    { 
      /*  while(pFOV.canSeePlayer == true)
        {
            m_AudioSource.PlayOneShot(attackClip);
        } */
    }

    private void Ambiance()
    {
        m_AudioSource.PlayOneShot(musicClip);
    }
}
