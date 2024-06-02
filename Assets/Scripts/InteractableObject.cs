using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool isInteractable;
    public Material highlightMaterial;
    private SpriteRenderer sr;
    private Material defaultMaterial;

    private void Start()
    {
        if (name == "Hitbox")
            sr = GetComponentInParent<SpriteRenderer>();
        else
            sr = GetComponent<SpriteRenderer>();
        defaultMaterial = sr.material;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isInteractable && other.CompareTag("PlayerTrigger") && other.transform.parent.GetComponent<Player>().isActive)
        {
            other.GetComponent<PlayerTrigger>().triggeredInteractableObjects.Add(gameObject);
            sr.material = highlightMaterial;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            other.GetComponent<PlayerTrigger>().triggeredInteractableObjects.Remove(gameObject);
            sr.material = defaultMaterial;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isInteractable && other.CompareTag("PlayerTrigger") && other.transform.parent.GetComponent<Player>().isActive)
        {
            other.GetComponent<PlayerTrigger>().triggeredInteractableObjects.Remove(gameObject);
            sr.material = defaultMaterial;
        }
    }
}
