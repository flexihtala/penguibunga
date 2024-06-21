using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Serialization;


public class MenuCanvaBehaviour : MonoBehaviour
{
    [SerializeField] private CanvasGroup menuCanvas;

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
        {
            return;
        }
        
        if (Math.Abs(menuCanvas.alpha - 1f) < 1e-9)
        {
            menuCanvas.alpha = 0;
            GameState.ActivePlayer.isActive = true;
        }
        else
        {
            if (!GameState.ActivePlayer.isActive) return;
            menuCanvas.alpha = 1;
            GameState.ActivePlayer.isActive = false;
        }
    }
}