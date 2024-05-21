using System.Collections.Generic;
using UnityEngine;

public class DotsManager : MonoBehaviour
{
    public bool isStarted;

    public bool isClicked;

    public Color defaultColor;

    public Color currentColor;

    public readonly HashSet<SpriteRenderer> UncompletedTiles = new();

    public readonly HashSet<SpriteRenderer> CurrentTiles = new();

    public readonly HashSet<Color> CompletedColors = new();

    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            isClicked = true;
        if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
            foreach (var tile in UncompletedTiles)
                tile.color = defaultColor;
            CurrentTiles.Clear();
            isStarted = false;
        }

        if (CompletedColors.Count >= 9 && UncompletedTiles.Count == 0)
        {
            GameState.IsOverGameWires = true;
        }
    }
}