using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private bool isTriggered;

    private Item item;

    private GameObject player;
    private InteractableObject interactableObject;

    // Start is called before the first frame update
    private void Start()
    {
        item = GetComponent<Item>();
        interactableObject = GetComponent<InteractableObject>();
        interactableObject.isInteractable = item.itemName == ItemName.Brick || item.itemName == ItemName.Nail;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("item was picked up");
            Destroy(gameObject);
            Inventory.Add(item);
            if (item.itemName == ItemName.Screwdriver)
                GameState.ChecksBool.Remove(DialogFlagEnum.Ventilation);
            if (item.itemName == ItemName.Crowbar)
            {
                if (GameState.ChecksBool.Contains(DialogFlagEnum.Keyboard))
                    GameState.ChecksBool.Add(DialogFlagEnum.ToiletDoor);
                else
                    GameState.ChecksBool.Add(DialogFlagEnum.Crowbar);
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
        {
            isTriggered = false;
        }
    }
}