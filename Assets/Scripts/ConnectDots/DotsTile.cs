using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsTile : MonoBehaviour
{
    public DotsManager dotsManager;
    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        dotsManager.defaultColor = sprite.color;
    }
    private void OnMouseOver()
    {
        if (dotsManager.isClicked)
        {
            sprite.color = Color.gray;
            dotsManager.Tiles.Add(sprite);
        }
    }
}
