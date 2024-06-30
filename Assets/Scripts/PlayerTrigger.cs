using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public bool isTriggered;
    public bool isGrounded;
    public Player otherPlayer;
    public bool isOnMovingPlatform;
    public HashSet<GameObject> triggeredInteractableObjects = new(); // review(27.06.2024): Разве GameObject можно использовать в Dictionary/HashSet?
    private MovingObject movingPlatform;

    private GameObject otherObject;

    private Player parentPlayer;

    private Rigidbody2D playerRigidbody;
    
    private GameObject playerSwapHint;
    private GameObject interactionHint;

    // Start is called before the first frame update
    private void Start()
    {
        var parent = transform.parent;
        parentPlayer = parent.GetComponent<Player>();
        playerRigidbody = parentPlayer.GetComponent<Rigidbody2D>();
        playerSwapHint = parent.GetChild(2).GetChild(2).gameObject;
        interactionHint = parent.GetChild(2).GetChild(1).gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        interactionHint.SetActive(triggeredInteractableObjects.Count > 0);
        if (isOnMovingPlatform)
        {
            var vector2 = playerRigidbody.position;
            vector2.x += movingPlatform.DeltaX;
            playerRigidbody.position = vector2;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        otherObject = other.gameObject;
        if (transform.parent.GetComponent<Player>().isActive 
            && transform.parent.gameObject != other.gameObject 
            && other.CompareTag("Player"))
        {
            isTriggered = true;
            playerSwapHint.SetActive(true);
            otherPlayer = otherObject.GetComponent<Player>();
        }
        if (other.CompareTag("MovingPlatform"))
        {
            movingPlatform = otherObject.GetComponent<MovingObject>();
            isOnMovingPlatform = true;
        }
        if (other.CompareTag("Ground") || other.CompareTag("MovingPlatform"))
            isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (transform.parent.GetComponent<Player>().isActive 
            && transform.parent.gameObject != other.gameObject 
            && other.CompareTag("Player"))
        {
            isTriggered = false;
            playerSwapHint.SetActive(false);
        }
        if (other.CompareTag("Ground") || other.CompareTag("MovingPlatform"))
            isGrounded = false;
        if (other.CompareTag("MovingPlatform"))
            isOnMovingPlatform = false;
    }
}