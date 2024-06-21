using System;
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
    private AudioManager audioManager;

    [SerializeField] private GameObject Light1;
    [SerializeField] private GameObject Light2;
    [SerializeField] private CanvasGroup menuCanvas;
    [SerializeField] private CanvasGroup tipsCanvas;

    
    private readonly List<SpriteRenderer> CompletedTiles = new();
    private bool isCoroutineStarted;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (Math.Abs(menuCanvas.alpha - 1f) < 1e-9 || Math.Abs(tipsCanvas.alpha - 1f) < 1e-9)
            return;
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
        if (CompletedColors.Count >= 5 && UncompletedTiles.Count == 0 && !isCoroutineStarted)
        {
            isCoroutineStarted = true;
            StartCoroutine(EndGame());
        }
    }

    public void SkipGame()
    {
        StartCoroutine(EndGame());
    }
    
    private IEnumerator EndGame()
    {
        GameState.ChecksBool.Remove(DialogFlagEnum.Electrical);
        GameState.IsOverGameWires = true;
        GameState.ChecksBool.Add(DialogFlagEnum.RoomDoor);
        audioManager.PlaySFX(audioManager.electricity);
        Light1.SetActive(false);
        Light2.SetActive(false);
        yield return new WaitForSeconds(1.5f);
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
    }
}