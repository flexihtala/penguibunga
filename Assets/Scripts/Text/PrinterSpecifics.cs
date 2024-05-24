using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PinterSpecifics : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textFrame;
    [SerializeField] private string text;
    [SerializeField] private float waitingTimeInterval = 0.065f;
    [SerializeField] private GameObject panel;
    private bool isTriggered;
    public float waitingTime = 99999f;
    public bool forKavazaki;
    public bool forKrico;
    public bool forEstriper;
    public bool forCago;
    public DialogFlagEnum FlagName;
    private int pressCount;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        var penguinName = other.gameObject.GetComponent<Player>().penguinName;
        if (!isTriggered 
            && ((penguinName == PenguinNames.Cago && forCago) 
                || (penguinName == PenguinNames.Kawazaki && forKavazaki)
                || (penguinName == PenguinNames.Krico && forKrico)
                || (penguinName == PenguinNames.Estriper && forEstriper))
            && GameState.ChecksBool.TryGetValue(FlagName, out _)
            && !GameState.IsNowTextDisplayed)
        {
            textFrame.text = string.Empty;
            isTriggered = true;
            StartCoroutine(TypeLine());
        }
    }
    
    private IEnumerator TypeLine()
    {
        GameState.ActivePlayer.isActive = false;
        GameState.IsNowTextDisplayed = true;
        panel.SetActive(true);
        foreach (var el in text)
        {
            textFrame.text += el;
            if (pressCount == 1)
                waitingTimeInterval = 0f;
            yield return new WaitForSeconds(waitingTimeInterval);
        }
        if (pressCount >= 2)
        {
            textFrame.text = string.Empty;
            panel.SetActive(false);
            GameState.ActivePlayer.isActive = true;
            GameState.IsNowTextDisplayed = false;
            waitingTimeInterval = 0.065f;
            pressCount = 0;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            pressCount++;
            Debug.Log(pressCount);
        }
    }
}
