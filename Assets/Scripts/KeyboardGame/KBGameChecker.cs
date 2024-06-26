using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// review(26.06.2024): вроде как не используется, можно было бы удалить
public class KBGameChecker : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // review(26.06.2024): Каждый раз в update гонять проверку - накладно. Исключаем те случаи, когда вы навешиваете и убираете компонент
        if (GameState.IsOverGameKeyboard)
            sprite.color = Color.gray;
    }
}
