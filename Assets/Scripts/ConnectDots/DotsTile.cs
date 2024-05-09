using UnityEngine;

public class DotsTile : MonoBehaviour
{
    public DotsManager dotsManager;
    public bool isHeadTile;
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        dotsManager.defaultColor = sprite.color;
        dotsManager.UncompletedTiles.Add(sprite);
    }

    private void OnMouseOver()
    {
        if (isHeadTile)
            dotsManager.currentColor = transform.GetChild(0).GetComponent<SpriteRenderer>().color;

        if (dotsManager.isClicked && sprite.color == dotsManager.defaultColor && !dotsManager.CompletedColors.Contains(sprite.color))
        {
            sprite.color = dotsManager.currentColor;
            dotsManager.CurrentTiles.Add(sprite);
            if (isHeadTile && dotsManager.CurrentTiles.Count > 1)
            {
                Debug.Log(sprite.color);
                foreach (var tile in dotsManager.CurrentTiles)
                {
                    dotsManager.UncompletedTiles.Remove(tile);
                }
                dotsManager.CompletedColors.Add(sprite.color);
            }
        }
    }
}