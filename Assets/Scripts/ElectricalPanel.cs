using System;
using UnityEngine;

public class ElectricalPanel : MonoBehaviour
{
    private bool isTriggered;
    public DotsManager dots;

    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            dots.gameObject.SetActive(true);
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
        {
            isTriggered = false;
            dots.isClicked = false;
            dots.gameObject.SetActive(false);
        }
    }
}