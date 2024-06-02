using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenVent : MonoBehaviour
{
    private bool isTriggered;

    private GameObject vent;
    private AudioManager audioManager;
    private InteractableObject interactableObject;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        vent = transform.parent.gameObject;
        interactableObject = GetComponent<InteractableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.PlayerInventory.ContainsKey(ItemName.Screwdriver))
        {
            interactableObject.isInteractable = true;
            if (isTriggered && Input.GetKeyDown(KeyCode.E))
            {
                audioManager.PlaySFX(audioManager.screwdriver);
                Destroy(vent);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isTriggered = false;
    }
}
