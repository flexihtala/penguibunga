using UnityEngine;

public class DoorPassage : MonoBehaviour
{
    public GameObject exitDoor;
    private bool isTriggered;
    private GameObject player;
    public ElectricalPanel electricalPanel;

    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            if (player is not null && electricalPanel.isGameFinished)
            {
                var vector3 = player.transform.position;
                var position = exitDoor.transform.position;
                vector3.x = position.x;
                vector3.y = position.y;
                player.gameObject.transform.position = vector3;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isTriggered = false;
    }
}