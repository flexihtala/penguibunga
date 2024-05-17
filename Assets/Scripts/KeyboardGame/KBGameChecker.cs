using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KBGameChecker : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (GameState.IsOverGameKeyboard)
            sprite.color = Color.gray;
    }
}
