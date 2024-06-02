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
    private readonly string answer = "2 7 3 4";

    private static readonly List<KeyCode> Alphabet = new()
    {
        KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
        KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7,
        KeyCode.Alpha8, KeyCode.Alpha9
    };

    void Start() 
        => text ??= GetComponent<TMP_Text>();

    void Update()
    {
        if (!GameState.IsOpenKeyboardGame)
            return;
        UpdateGame();
    }

    private void UpdateGame()
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

        if (text.text.Length >= answer.Length)
            return;

        var pressedKey = Alphabet.Where(Input.GetKeyDown).Select(x => GetDigit(x)).ToArray();

        if (!pressedKey.Any())
            return;

        var el = pressedKey.FirstOrDefault();

        var newDigit = Alphabet[el].ToString()[^1];

        if (text.text.Length != 0)
            text.text += " ";

        text.text += newDigit;

        keyAnimators[(newDigit - '0' + 8) % 10].Play("PressKey");
    }

    private int GetDigit(KeyCode? key)
        => (key.ToString()[^1] - '0' + 12) % Alphabet.Count;
}