using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private bool isTriggered;

    private Item item;

    private GameObject player;
    private AudioManager audioManager;

    // Start is called before the first frame update
    private void Start()
    {
        item = GetComponent<Item>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("item was picked up");
            audioManager.PlaySFX(audioManager.pickup);
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
        if (other.CompareTag("Player") && other.GetComponent<Player>().isActive)
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