using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseButton : MonoBehaviour
{
    public DotsManager dotsManager;

    void EraseField() // review(17.06.2024): Метод не используется, можно удалить
    {
        if (!GameState.IsOverGameWires) 
            dotsManager.EraseField();
    }
}
