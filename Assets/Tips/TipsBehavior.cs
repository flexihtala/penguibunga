using System;
using UnityEngine;


public class TipsBehavior : MonoBehaviour
{
    [SerializeField] private CanvasGroup tipsCanvas;
    [SerializeField] private GameObject buttonHelp;

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.H))
            return;
        if (Math.Abs(tipsCanvas.alpha - 1f) < 1e-9)
        {
            tipsCanvas.alpha = 0;
            buttonHelp.SetActive(true);
            GameState.ActivePlayer.isActive = true;
        }
        else
        {
            if (!GameState.ActivePlayer.isActive) return;
            tipsCanvas.alpha = 1;
            GameState.ActivePlayer.isActive = false;
            buttonHelp.SetActive(false);
        }
    }
}