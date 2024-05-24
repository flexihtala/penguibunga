using System.Collections;
using TMPro;
using UnityEngine;

public class ElectricalPanel : MonoBehaviour
{
    public DotsManager dots;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] public string line;
    [SerializeField] private float textSpeed = 0.1f;
    public GameObject panel;
    private bool isStupid = true;
    private bool isTriggered;

    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
            dots.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // review(24.05.2024): if (!other.CompareTag("Player")) return;
        // review(24.05.2024): А еще можно просто отнаследовать PlayerTrigger : BoxCollider и в нем реализовать одну и ту же проверку на игрока 
        if (other.CompareTag("Player") && other.gameObject.GetComponent<Player>().penguinName == PenguinNames.Kawazaki)
            isTriggered = true;
        else if (isStupid && other.CompareTag("Player"))
        {
            isStupid = false;
            StartCoroutine(TypeLine());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
            dots.isClicked = false;
            dots.gameObject.SetActive(false);
        }
    }

    // review(24.05.2024): Код дублируется. Стоит выделить класс, который занимается печатью текста
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