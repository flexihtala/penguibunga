using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardGame : MonoBehaviour
{
    public GameObject game;
    private bool isTriggered;

    private void Awake()
    {
        game.SetActive(false);
    }

    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            game.SetActive(true);
            GameState.IsOpenKeyboardGame = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Player>().penguinName == PenguinNames.Kawazaki)
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
            game.SetActive(false);
            GameState.IsOpenKeyboardGame = false;
        }
    }
}
