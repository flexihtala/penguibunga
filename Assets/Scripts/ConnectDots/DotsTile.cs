using TMPro;
using UnityEngine;

public class DotsTile : MonoBehaviour
{
    public DotsManager dotsManager;
    public bool isHeadTile;
    private SpriteRenderer sprite;
    private Color endColor;

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
                dotsManager.isStarted = true;
        }

        if (dotsManager.isStarted && sprite.color == dotsManager.defaultColor && !dotsManager.CompletedColors.Contains(sprite.color))
        {
            sprite.color = dotsManager.currentColor;
            dotsManager.CurrentTiles.Add(sprite);
            Debug.Log(endColor);
            Debug.Log(dotsManager.currentColor);
            Debug.Log(isHeadTile);
            Debug.Log(dotsManager.CurrentTiles.Count);
            if (isHeadTile && dotsManager.CurrentTiles.Count > 1 && endColor.CompareRGB(dotsManager.currentColor))
            {
                Debug.Log(endColor);
                Debug.Log(dotsManager.currentColor);
                foreach (var tile in dotsManager.CurrentTiles)
                {
                    dotsManager.UncompletedTiles.Remove(tile);
                }
                dotsManager.CompletedColors.Add(sprite.color);
            }
        }
    }
}