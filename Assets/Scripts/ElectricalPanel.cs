using UnityEngine;

public class ElectricalPanel : MonoBehaviour
{
    private bool isTriggered;

    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
            GameState.IsOverGameWires = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isTriggered = false;
    }
}