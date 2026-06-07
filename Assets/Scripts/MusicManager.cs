using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    public AudioSource audioSource;
    public AudioClip gameMusic;
    public AudioClip gameOverMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayGameMusic()
    {
        audioSource.Stop();
        audioSource.clip = gameMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayGameOverMusic()
    {
        audioSource.Stop();
        audioSource.clip = gameOverMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}