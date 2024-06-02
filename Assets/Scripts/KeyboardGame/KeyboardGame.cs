using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardGame : MonoBehaviour
{
    public GameObject game;
    private bool isTriggered;
    private InteractableObject interactableObject;
    private bool showGame;

    private void Awake()
    {
        game.SetActive(false);
        interactableObject = GetComponent<InteractableObject>();
    }

    private void Update()
    {
        interactableObject.isInteractable = GameState.ActivePlayer.penguinName == PenguinNames.Kawazaki;
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            showGame = !showGame;
            game.SetActive(showGame);
            GameState.IsOpenKeyboardGame = showGame;
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
