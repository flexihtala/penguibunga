using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup menuCanvas;
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Return()
    {
        menuCanvas.alpha = 0;
        GameState.ActivePlayer.isActive = true;
    }
    
}
