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
        sr = GetComponent<SpriteRenderer>();
        defaultMaterial = sr.material;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isInteractable && other.CompareTag("Player") && other.GetComponent<Player>().isActive)
            sr.material = highlightMaterial;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
           sr.material = defaultMaterial;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isInteractable)
            sr.material = defaultMaterial;
    }
}
