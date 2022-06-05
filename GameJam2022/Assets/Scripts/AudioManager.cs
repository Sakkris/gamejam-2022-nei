using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource mainMusic;
    [SerializeField] AudioSource mainMusicLoop;
    [SerializeField] AudioSource gameOverMusic;

    public void Awake()
    {
        mainMusic.Play();
    }
    public void Update()
    {
        if (!mainMusic.isPlaying)
        {
            mainMusicLoop.Play();
        }
    }
    public void GameOverPlayer()
    {
        if (mainMusic.isPlaying)
        {
            mainMusic.Stop();
        }
        if (mainMusicLoop.isPlaying)
        {
            mainMusicLoop.Stop();
        }
        gameOverMusic.Play();
    }
}
