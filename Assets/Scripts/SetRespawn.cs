using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRespawn : MonoBehaviour
{
    public GameObject gameObject;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameState.PlatformerSpawn = gameObject.transform.position;
        }
    }
}
