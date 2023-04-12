using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Function Parameters")]
    [SerializeField] private bool useAmbiance = true;

    [Header("Audio Parameters")]
    public AudioSource m_AudioSource;
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioClip attackClip;

    [Header("Refrences")]
    [SerializeField] private PirateFOV pFOV;

    private static AudioManager instance = null;

    public static AudioManager Instance { get { return instance; }}

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

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
