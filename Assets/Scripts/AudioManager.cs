using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip BGM;
    public AudioClip DoubleBGM;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        instance.audioSource = GetComponent<AudioSource>();
    }
    public void ChangeBGM()
    {
        instance.BGMPause();
        if (ScoreManager.instance.isdouble)
        {
            instance.audioSource.clip = instance.DoubleBGM;
        }
        else
        {
            instance.audioSource.clip = instance.BGM;
        }
        instance.BGMPlay();
    }
    public void BGMPlay()
    {
        instance.audioSource.Play();
    }
    public void BGMPause()
    {
        instance.audioSource.Pause();
    }
}
