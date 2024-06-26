using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftItem : MonoBehaviour
{
    private bool isTriggered;
    private InteractableObject interactableObject;
    public GameObject screwdriver;
    // Start is called before the first frame update
    void Start()
    {
        screwdriver.SetActive(false);
        interactableObject = transform.parent.GetComponent<InteractableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        var hasBrickAndNail = Inventory.PlayerInventory.ContainsKey(ItemName.Nail) &&
                              Inventory.PlayerInventory.ContainsKey(ItemName.Brick); // review(27.06.2024): Уместнее было инкапсулировать логику проверки вещей в метод Inventory.Contains(...)
        if (hasBrickAndNail)
            interactableObject.isInteractable = true;
            
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            if (hasBrickAndNail)
            {
                Inventory.Remove(ItemName.Nail);
                Inventory.Remove(ItemName.Brick);
                screwdriver.SetActive(true);
                interactableObject.isInteractable = false;
                screwdriver.GetComponent<InteractableObject>().isInteractable = true;
                Debug.Log("Скрафчена отвертка");
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
