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
    public AudioClip click;
    public AudioClip pickup;
    public AudioClip door;
    public AudioClip dash;
    public AudioClip screwdriver;
    public AudioClip death;
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
}
