using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ElectricalPanel : MonoBehaviour
{
    public DotsManager dots;
    private bool isTriggered;
    private bool showGame;
    private InteractableObject interactableObject;

    private void Start()
    {
        interactableObject = GetComponent<InteractableObject>();
    }

    private void Update()
    {
        interactableObject.isInteractable = GameState.ActivePlayer.penguinName == PenguinNames.Estriper;
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            showGame = !showGame;
            dots.gameObject.SetActive(showGame);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return; 
        isTriggered = other.gameObject.GetComponent<Player>().penguinName == PenguinNames.Estriper;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
            dots.isClicked = false;
            dots.gameObject.SetActive(false);
            interactableObject.isInteractable = false;
        }
    }
}