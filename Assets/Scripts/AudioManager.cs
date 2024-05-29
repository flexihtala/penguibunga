using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioSource steps;

    public AudioClip background;
    public AudioClip coridorBackground;
    public AudioClip click;

    private void Start()
    {
        musicSource.clip = background;
        GameState.CurrentMusic = background;
        musicSource.Play();
    }

    public void ChangeMusic(AudioClip music)
    {
        musicSource.Stop();
        musicSource.clip = music;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void StartSteps()
    {
        steps.Play();
    }

    public void StopSteps()
    {
        steps.Stop();
    }
}
