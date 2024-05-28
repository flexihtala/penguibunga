using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseButton : MonoBehaviour
{
    public DotsManager dotsManager;
    private void OnMouseDown()
    {
        dotsManager.EraseField();
    }
}
