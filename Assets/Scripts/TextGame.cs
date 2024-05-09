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
    private string answer = "2 3 5 8";

    private static List<KeyCode> Alphabet = new()
    {
        KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
        KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7,
        KeyCode.Alpha8, KeyCode.Alpha9
    };

    void Start()
    {
        if (text == null)
            text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (text.text == answer)
            return;
        if (Input.GetKeyDown(KeyCode.Backspace) && text.text.Length > 0)
            text.text = "";
        if (text.text.Length == answer.Length)
            return;
        foreach (var el in Alphabet)
        {
            if (Input.GetKeyDown(el))
            {
                var nexIndex = (Int32.Parse((el.ToString()[^1]).ToString()) + 2) % Alphabet.Count;
                var newDigit = Alphabet[nexIndex].ToString()[^1];
                if (text.text.Length != 0)
                    text.text += " ";
                text.text += newDigit;
            }
        }
    }
}