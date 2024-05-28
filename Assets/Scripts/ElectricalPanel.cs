using System.Collections;
using TMPro;
using UnityEngine;

public class ElectricalPanel : MonoBehaviour
{
    public DotsManager dots;
    private bool isTriggered;
    private bool showGame;

    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            showGame = !showGame;
            dots.gameObject.SetActive(showGame);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        if (other.gameObject.GetComponent<Player>().penguinName == PenguinNames.Estriper)
            isTriggered = true;
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
}