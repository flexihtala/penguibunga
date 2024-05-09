using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KBGameChecker : MonoBehaviour
{
    public TextPuzzle game;
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (game.isFinished)
            sprite.color = Color.gray;
    }
}
