using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TriggerPrinterText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI font;
    [SerializeField] private string text;
    [SerializeField] private float waitingTimeInterval = 0.1f;
    public GameObject panel;
    private bool isTriggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            font.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    protected IEnumerator TypeLine()
    {
        panel.SetActive(true);
        foreach (var el in text)
        {
            font.text += el;
            yield return new WaitForSeconds(waitingTimeInterval);
        }

        yield return new WaitForSeconds(2);
        font.text = string.Empty;
        panel.SetActive(false);
    }
}