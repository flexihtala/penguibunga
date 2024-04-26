using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenVent : MonoBehaviour
{
    private bool isTriggered;

    private GameObject vent;

    // Start is called before the first frame update
    void Start()
    {
        vent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            if(Inventory.PlayerInventory.Contains("Screwdriver"))
                Destroy(vent);
            else
                Debug.Log("у тебя нет отвертки");
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
