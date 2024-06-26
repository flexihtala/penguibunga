using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PinterSpecifics : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textFrame;
    [SerializeField] private string text;
    [SerializeField] private float waitingTimeInterval = 0.065f;
    [SerializeField] private GameObject panel;
    private bool isTriggered;
    public bool forKavazaki;
    public bool forKrico;
    public bool forEstriper;
    public bool forCago;
    public DialogFlagEnum FlagName;
    public float waitingTime = 2f;
    public bool freezePlayer;
    public bool instantText;
    private bool isDialog;
    public bool multipleText;
    private Collider2D PlayerCollider;

    private void Update()
    {
        if (isTriggered)
        {
            var penguinName = PlayerCollider.gameObject.GetComponent<Player>().penguinName;
            if ((!isDialog || multipleText)
                && ((penguinName == PenguinNames.Cago && forCago)
                    || (penguinName == PenguinNames.Kawazaki && forKavazaki)
                    || (penguinName == PenguinNames.Krico && forKrico)
                    || (penguinName == PenguinNames.Estriper && forEstriper))
                && GameState.ChecksBool.TryGetValue(FlagName, out var dialogFlag)
                && !GameState.IsNowTextDisplayed)
            {
                textFrame.text = string.Empty;
                isDialog = true;
                StartCoroutine(TypeLine());
                isTriggered = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        PlayerCollider = other;
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        isTriggered = false;
        PlayerCollider = null;
    }

    private IEnumerator TypeLine()
    {
        if (freezePlayer)
            GameState.ActivePlayer.isActive = false;
        GameState.IsNowTextDisplayed = true;
        panel.SetActive(true);
        if (!instantText)
            foreach (var el in text)
            {
                textFrame.text += el;
                yield return new WaitForSeconds(waitingTimeInterval);
            }
        else
            textFrame.text = text;
        yield return new WaitForSeconds(waitingTime);
        textFrame.text = string.Empty;
        panel.SetActive(false);
        if (freezePlayer)
            GameState.ActivePlayer.isActive = true;
        GameState.IsNowTextDisplayed = false;
        waitingTimeInterval = 0.065f;
    }
}