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
    private string answer = "2 7 3 4";

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
        {
            GameState.IsOverGameKeyboard = true;
            if (GameState.ChecksBool.Contains(DialogFlagEnum.Crowbar))
                GameState.ChecksBool.Add(DialogFlagEnum.ToiletDoor);
            else
                GameState.ChecksBool.Add(DialogFlagEnum.Keyboard);
        }
        if (Input.GetKeyDown(KeyCode.Backspace) && text.text.Length > 0)
        {
            text.text = "";
            keyAnimators[10].Play("PressKey");
        }

        if (text.text.Length == answer.Length)
            return;
        foreach (var el in Alphabet)
        {
            if (!Input.GetKeyDown(el)) continue;
            var nexIndex = (Int32.Parse((el.ToString()[^1]).ToString()) + 2) % Alphabet.Count;
            var newDigit = Alphabet[nexIndex].ToString()[^1];
            if (text.text.Length != 0)
                text.text += " ";
            text.text += newDigit;
                
            keyAnimators[newDigit - '0'].Play("PressKey");
        }
    }
}