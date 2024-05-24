using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class TextPuzzle : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [SerializeField] private Animator[] keyAnimators;
    private string answer = "2 3 5 8";

    private static List<KeyCode> Alphabet = new()
    {
        KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
        KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7,
        KeyCode.Alpha8, KeyCode.Alpha9
    };

    void Start()
    {
        // review(24.05.2024): text ??= GetComponent<TMP_Text>();
        if (text == null)
            text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        // review(24.05.2024): Правильно ли я понял, что даже если TextPuzzle не активен, он все равно будет выполнять метод Update?
        if (text.text == answer)
            GameState.IsOverGameKeyboard = true;
        if (Input.GetKeyDown(KeyCode.Backspace) && text.text.Length > 0)
        {
            text.text = "";
            keyAnimators[10].Play("PressKey");
        }

        if (text.text.Length == answer.Length)
            return;
        // review(24.05.2024): Если предполагается, что числа вводятся по одному, тогда зачем тут foreach?
        // Можно же через FirstOrDefault() найти нужную кнопку и с ней работать
        foreach (var el in Alphabet)
        {
            if (!Input.GetKeyDown(el)) continue; // review(24.05.2024): На новую строку
            // review(24.05.2024): Я бы выделил класс-хелпер, который бы умел KeyCodes.GetDigit(KeyCode key): KeyCode -> int и скрыл бы там всю эту сложность
            var nexIndex = (Int32.Parse((el.ToString()[^1]).ToString()) + 2) % Alphabet.Count;
            var newDigit = Alphabet[nexIndex].ToString()[^1];
            if (text.text.Length != 0)
                text.text += " ";
            text.text += newDigit;
                
            keyAnimators[newDigit - '0'].Play("PressKey");
        }
    }
}