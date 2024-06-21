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
    [SerializeField] private GameObject RedLamp;
    [SerializeField] private GameObject GamePanel;
    [SerializeField] private CanvasGroup menuCanvas;
    [SerializeField] private CanvasGroup tipsCanvas;
    private string answer = "2 7 3 4";

    private static List<KeyCode> Alphabet = new()
    {
        KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
        KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7,
        KeyCode.Alpha8, KeyCode.Alpha9
    };

    private IEnumerator EndGame()
    {
        RedLamp.SetActive(false);
        GameState.IsOverGameKeyboard = true;
        GameState.ChecksBool.Add(DialogFlagEnum.Keyboard);
        if (GameState.ChecksBool.Contains(DialogFlagEnum.Crowbar))
            GameState.ChecksBool.Add(DialogFlagEnum.ToiletDoor);
        else
            GameState.ChecksBool.Add(DialogFlagEnum.OnlyKeyboard);
        yield return new WaitForSeconds(1.5f);
        GameState.ChecksBool.Remove(DialogFlagEnum.KeyboardForStupid);
        GamePanel.SetActive(false);
    }

    void Start()
    {
        if (text == null)
            text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (Math.Abs(menuCanvas.alpha - 1f) < 1e-9 || Math.Abs(tipsCanvas.alpha - 1f) < 1e-9)
            return;
        if (text.text == answer)
        {
            StartCoroutine(EndGame());
        }

        if (Input.GetKeyDown(KeyCode.Backspace) && text.text.Length > 0)
        {
            text.text = "";
            keyAnimators[10].Play("PressKey");
        }

        if (text.text.Length >= answer.Length)
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