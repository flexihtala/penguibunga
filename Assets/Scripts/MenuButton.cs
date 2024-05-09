using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public GameObject unhighlighted;
    public GameObject highlighted;

    private void OnMouseOver()
    {
        unhighlighted.SetActive(false);
        highlighted.SetActive(true);
    }

    private void OnMouseExit()
    {
        gameObject.SetActive(false);
        unhighlighted.SetActive(true);
    }
}
