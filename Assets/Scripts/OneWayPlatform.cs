using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    public PlatformEffector2D platformEffector;
    private bool isTriggered;
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            if (isTriggered && Input.GetKeyDown(KeyCode.S))
            {
                platformEffector.rotationalOffset = 180;
            }
        }
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }
    
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isTriggered = false;
            platformEffector.rotationalOffset = 0;
        }
    }
}
