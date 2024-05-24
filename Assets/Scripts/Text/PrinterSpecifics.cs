using System.Collections;
using TMPro;
using UnityEngine;

public class PinterSpecifics : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textFrame;
    [SerializeField] private string text;
    [SerializeField] private float waitingTimeInterval = 0.065f;
    [SerializeField] private GameObject panel;
    public bool forKavazaki;
    public bool forKrico;
    public bool forEstriper;
    public bool forCago;
    public DialogFlagEnum FlagName;
    public float waitingTime = 2f;
    public bool freezePlayer;
    public bool instantText;
    private bool isTriggered;

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