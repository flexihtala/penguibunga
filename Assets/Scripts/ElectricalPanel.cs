using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalPanel : MonoBehaviour
{
    private bool isTriggered;
    public bool isGameFinished;
    void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            isGameFinished = true;
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
