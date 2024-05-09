using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class TextPuzzle : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private int offset = 7;
    private string sample = "VZLOM ASS";

    private HashSet<KeyCode> alphabet = new()
    {
        KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F,
        KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M,
        KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T,
        KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z,
    };


    void Start()
    {
        if (text == null)
            text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (text.text.Length == sample.Length && !Input.GetKeyDown(KeyCode.Backspace))
            return;
        if (text.text == sample)
            return;
        if (Input.GetKeyDown(KeyCode.Backspace) && text.text.Length > 0)
            text.text.Remove(text.text.Length - 1);
        foreach (var el in alphabet)
        {
            if (Input.GetKeyDown(el))
            {
                text.text += el.ToString();
            }   
        }
    }
}