using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DotsTile : MonoBehaviour
{
    public DotsManager dotsManager;
    public bool isHeadTile; 
    private SpriteRenderer sprite;
    private Color endColor;
    public List<GameObject> adjacentTiles;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        dotsManager.defaultColor = sprite.color;
        dotsManager.UncompletedTiles.Add(sprite);
        if (isHeadTile)
            endColor = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
    }

    private void OnMouseOver()
    {
        if (isHeadTile && !dotsManager.isStarted)
        {
            dotsManager.currentColor = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
            if (dotsManager.isClicked)
            {
                sprite.color = dotsManager.currentColor;
                dotsManager.CurrentTiles.Add(sprite);
                dotsManager.prevTile = gameObject;
                dotsManager.isStarted = true;
            }
        }
        if (dotsManager.isClicked && sprite.color == dotsManager.defaultColor && !dotsManager.CompletedColors.Contains(sprite.color)
            && adjacentTiles.Contains(dotsManager.prevTile))
        {
            if (isHeadTile && dotsManager.currentColor != endColor)
                return;
            sprite.color = dotsManager.currentColor;
            dotsManager.prevTile = gameObject;
            dotsManager.CurrentTiles.Add(sprite);
            Debug.Log(sprite.transform.position);
            Debug.Log(dotsManager.CurrentTiles[^2].transform.position);
            if (isHeadTile && dotsManager.CurrentTiles.Count > 1 && endColor == dotsManager.currentColor)
            {
                foreach (var tile in dotsManager.CurrentTiles)
                {
                    dotsManager.UncompletedTiles.Remove(tile);
                }

                dotsManager.isClicked = false;
                dotsManager.CompletedColors.Add(sprite.color);
                return;
            }
        }
        if (dotsManager.CurrentTiles.Count > 1 && sprite == dotsManager.CurrentTiles[^2])
        {
            dotsManager.prevTile = dotsManager.CurrentTiles[^2].gameObject;
            dotsManager.CurrentTiles[^1].color = dotsManager.defaultColor;
            dotsManager.CurrentTiles.RemoveAt(dotsManager.CurrentTiles.Count - 1);
        }
        
    }
}
