using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

public class DotsManager : MonoBehaviour
{
    public bool isStarted;

    public bool isClicked;

    public Color defaultColor;

    public Color currentColor;

    public readonly HashSet<SpriteRenderer> UncompletedTiles = new();

    public readonly List<SpriteRenderer> CurrentTiles = new();

    public readonly HashSet<Color> CompletedColors = new();

    public GameObject prevTile;

    [SerializeField] private GlobalLightState globalLightState;
    
    private readonly List<SpriteRenderer> CompletedTiles = new();

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
            prevTile = null;
            CurrentTiles.Clear();
            isStarted = false;
        }
        if (CompletedColors.Count >= 5 && UncompletedTiles.Count == 0)
        {
            StartCoroutine(EndGame());
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
            EraseField();
    }

    private IEnumerator EndGame()
    {
        GameState.IsOverGameWires = true;
        GameState.ChecksBool.Add(DialogFlagEnum.RoomDoor);
        yield return new WaitForSeconds(2f);
        globalLightState.TurnOffLight();
        gameObject.SetActive(false);
    }
    
    public void EraseField()
    {
        foreach (var tile in CompletedTiles)
        {
            UncompletedTiles.Add(tile);
            tile.color = defaultColor;
        }

        CompletedTiles.Clear();
        ;
    }
}