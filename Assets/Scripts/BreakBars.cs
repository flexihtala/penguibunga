using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBars : MonoBehaviour
{
    private bool isTriggered;
    [SerializeField] private GameObject brokenBars;
    [SerializeField] private GameObject wholeBars;
    private InteractableObject interactableObject;

    private void Start()
    {
        interactableObject = GetComponent<InteractableObject>();
    }

    void Update()
    {
        if (GameState.IsOverGameKeyboard
            && GameState.HaveCrowbar)
            interactableObject.isInteractable = true;
        if (GameState.IsOverGameKeyboard
            && GameState.HaveCrowbar
            && isTriggered
            && Input.GetKeyDown(KeyCode.E))
        {
            brokenBars.SetActive(true);
            StartCoroutine(Wait(0.2f));
            wholeBars.SetActive(false);
            GameState.CanOpenToiletDoor = true;
        }
    }
    
    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isTriggered = false;
    }
}
