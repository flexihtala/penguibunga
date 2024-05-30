using System;
using UnityEngine;

public class DoorPassage : MonoBehaviour
{
    public Door doorType;
    public GameObject exitDoor;
    private bool isTriggered;
    private Player player;
    private InteractableObject interactableObject;

    private void Start()
    {
        interactableObject = GetComponent<InteractableObject>();
    }

    private void Update()
    {
        interactableObject.isInteractable = GameState.IsOverGameWires;
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            if ((GameState.IsOverGameWires && doorType == Door.RoomDoor)
                || (GameState.IsOverGameKeyboard && GameState.HaveCrowbar && doorType == Door.ToiletDoor)
                || (GameState.HaveCrowbar && doorType == Door.Ventilation))
            {
                var vector3 = player.transform.position;
                var position = exitDoor.transform.position;
                vector3.x = position.x;
                vector3.y = position.y;
                player.gameObject.transform.position = vector3;
            }
            else if (doorType == Door.RoomDoor)
            {
                Debug.Log("Получил флаг");
                GameState.ChecksBool.Add(DialogFlagEnum.RoomDoorClosed);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            player = other.gameObject.GetComponent<Player>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isTriggered = false;
    }
}