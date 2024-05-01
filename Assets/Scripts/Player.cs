using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PenguinNames penguinName;

    public PlayerController controller;
    
    public bool isActive;
    
    private PlayerTrigger playerTrigger;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerTrigger = transform.GetChild(0).GetComponent<PlayerTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && playerTrigger.isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            playerTrigger.gameObject.SetActive(false);
            isActive = false;
            playerTrigger.otherPlayer.isActive = true;
            playerTrigger.gameObject.SetActive(true);
        }
        
        controller.enabled = isActive;
    }
}
