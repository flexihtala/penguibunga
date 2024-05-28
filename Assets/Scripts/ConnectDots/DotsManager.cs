using System.Collections.Generic;
using UnityEngine;

public class DotsManager : MonoBehaviour
{
    public bool isStarted;

    public bool isClicked;

    public Color defaultColor;

    public Color currentColor;

    public readonly HashSet<SpriteRenderer> UncompletedTiles = new();

    public readonly List<SpriteRenderer> CurrentTiles = new();

    private readonly List<SpriteRenderer> CompletedTiles = new();

    public readonly HashSet<Color> CompletedColors = new();
    
    public GameObject prevTile;


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
            CompletedTiles.AddRange(CurrentTiles);
            CurrentTiles.Clear();
            isStarted = false;
        }

        if (CompletedColors.Count >= 5 && UncompletedTiles.Count == 0)
        {
            GameState.IsOverGameWires = true;
            GameState.ChecksBool.Add(DialogFlagEnum.RoomDoor);
        }
        
        if (Input.GetKeyDown(KeyCode.Backspace))
            EraseField();
    }
    public void EraseField()
    {
        foreach (var tile in CompletedTiles)
        {
            UncompletedTiles.Add(tile);
            tile.color = defaultColor;
        }
        CompletedTiles.Clear();;
    }
}