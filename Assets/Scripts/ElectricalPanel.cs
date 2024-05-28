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
        var isEstriper = other.gameObject.GetComponent<Player>().penguinName == PenguinNames.Estriper;
        interactableObject.isInteractable = isEstriper;
        isTriggered = isEstriper;
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