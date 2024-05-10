using System.Collections;
using TMPro;
using UnityEngine;

public class TriggerPrinterText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] public string line;
    [SerializeField] private float textSpeed = 0.1f;
    public GameObject panel;
    private bool isTriggered = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isTriggered)
        {
            isTriggered = false;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    private IEnumerator TypeLine()
    {
        panel.SetActive(true);
        foreach (var el in line)
        {
            text.text += el;
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(2);
        text.text = string.Empty;
        panel.SetActive(false);
    }
}