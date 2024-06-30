using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DotsTile : MonoBehaviour
{
    public DotsManager dotsManager;
    public bool isHeadTile; // review(17.06.2024): Как будто isEmpty звучит понятнее
    private SpriteRenderer sprite;
    private Color endColor;
    public List<GameObject> adjacentTiles; // review(17.06.2024): Очень надеюсь, что вы не руками проставляли adjacentTiles... Кажется, что саму карту можно было построить из кода (что было бы даже проще)

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        dotsManager.defaultColor = sprite.color;
        dotsManager.UncompletedTiles.Add(sprite); // review(17.06.2024): Тут как раз нарушается MVP: вы основываете решение о незаконченных тайлах на основе их цвета, а не строите внутреннюю модель
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
                // review(17.06.2024): Всю логику dotsManager-а можно было бы запихнуть внутрь dotsManager.Click(gameObject)
                dotsManager.CurrentTiles.Add(sprite);
                dotsManager.prevTile = gameObject;
                dotsManager.isStarted = true;
            }
        }

        if (dotsManager.isClicked && sprite.color == dotsManager.defaultColor &&
            !dotsManager.CompletedColors.Contains(sprite.color)
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

                dotsManager.CompletedColors.Add(endColor);
                dotsManager.isClicked = false;
                return;
            }
        }

        // review(17.06.2024): Всю логику ниже стоило поместить в DotsManager
        if (dotsManager.CurrentTiles.Count > 1 && sprite == dotsManager.CurrentTiles[^2] && dotsManager.isClicked)
        {
            dotsManager.prevTile = dotsManager.CurrentTiles[^2].gameObject;
            dotsManager.CurrentTiles[^1].color = dotsManager.defaultColor;
            dotsManager.CurrentTiles.RemoveAt(dotsManager.CurrentTiles.Count - 1);
        }

    }

}
