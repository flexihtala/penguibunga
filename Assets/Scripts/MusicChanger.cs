using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public AudioClip music;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && music != GameState.CurrentMusic)
        {
            GameState.CurrentMusic = music; // review(26.06.2024): Коль скоро вы задаете исходную музыку в самом audioManager, то стоило и изменение CurrentMusic поместить в audioManager.ChangeMusic
            audioManager.ChangeMusic(music);
        }
    }
}
