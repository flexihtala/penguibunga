using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PinterSpecifics : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textFrame;
    [SerializeField] private string text;
    [SerializeField] private float waitingTimeInterval = 0.1f;
    [SerializeField] private GameObject panel;
    private bool isTriggered;
    public bool forKavazaki;
    public bool forKrico;
    public bool forEstriper;
    public bool forCago;
    public DialogFlagEnum FlagName;

    private void OnTriggerEnter2D(Collider2D other)
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
        GameState.IsNowTextDisplayed = true;
        panel.SetActive(true);
        foreach (var el in text)
        {
            textFrame.text += el;
            yield return new WaitForSeconds(waitingTimeInterval);
        }

        yield return new WaitForSeconds(2);
        textFrame.text = string.Empty;
        panel.SetActive(false);
        GameState.IsNowTextDisplayed = false;
    }
}
