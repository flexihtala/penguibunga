using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public bool isTriggered;
    
    private Player parentPlayer;

    public Player otherPlayer;
    // Start is called before the first frame update
    void Start()
    {
        parentPlayer = transform.parent.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private bool IsValidCollision(Collider2D other)
    {
        return parentPlayer.isActive && transform.parent.gameObject != other.gameObject && other.CompareTag("Player");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (transform.parent.GetComponent<Player>().isActive && transform.parent.gameObject != other.gameObject && other.CompareTag("Player"))
        {
            isTriggered = true;
            otherPlayer = other.gameObject.GetComponent<Player>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (transform.parent.GetComponent<Player>().isActive && transform.parent.gameObject != other.gameObject && other.CompareTag("Player"))
            isTriggered = false;
    }
}
