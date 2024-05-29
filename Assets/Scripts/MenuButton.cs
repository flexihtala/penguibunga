using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler
{
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("A");
        audioManager.PlaySFX(audioManager.click);
        Debug.Log("B");
    }
}
