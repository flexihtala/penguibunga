using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftItem : MonoBehaviour
{
    private bool isTriggered;

    public GameObject screwdriver;
    // Start is called before the first frame update
    void Start()
    {
        screwdriver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            if (Inventory.PlayerInventory.Contains("Nail") && Inventory.PlayerInventory.Contains("Brick"))
            {
                Inventory.PlayerInventory.Remove("Nail");
                Inventory.PlayerInventory.Remove("Brick");
                screwdriver.SetActive(true);
                Debug.Log("Скрафчена отвертка");
            }
            else
            {
                Debug.Log("У тебя чего то нет");
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
