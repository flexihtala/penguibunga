using System;
using UnityEngine;

public class DoorPassage : MonoBehaviour
{
    public Door doorType;
    public GameObject exitDoor;
    private bool isTriggered;
    private Player player;
    private InteractableObject interactableObject;
    private AudioManager audioManager;
    private void Start()
    {
        interactableObject = GetComponent<InteractableObject>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (doorType == Door.ToiletDoor)
            interactableObject.isInteractable = GameState.CanOpenToiletDoor;
        if (doorType == Door.Ventilation)
            interactableObject.isInteractable = GameState.HaveCrowbar;
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            if ((GameState.IsOverGameWires && doorType == Door.RoomDoor)
                || (GameState.CanOpenToiletDoor && doorType == Door.ToiletDoor)
                || (GameState.HaveCrowbar && doorType == Door.Ventilation))
            {
                audioManager.PlaySFX(audioManager.door);
                var vector3 = player.transform.position;
                var position = exitDoor.transform.position;
                vector3.x = position.x;
                vector3.y = position.y;
                player.gameObject.transform.position = vector3;
            }
            else if (doorType == Door.RoomDoor)
            {
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