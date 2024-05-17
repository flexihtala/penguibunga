using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public bool isTriggered;
    public bool isGrounded;
    public Player otherPlayer;
    public bool isOnMovingPlatform;
    private MovingPlatform movingPlatform;

    private GameObject otherObject;

    private Player parentPlayer;

    private Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    private void Start()
    {
        parentPlayer = transform.parent.GetComponent<Player>();
        playerRigidbody = parentPlayer.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isOnMovingPlatform)
        {
            var vector2 = playerRigidbody.position;
            vector2.x += movingPlatform.deltaX;
            playerRigidbody.position = vector2;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        otherObject = other.gameObject;
        if (transform.parent.GetComponent<Player>().isActive && transform.parent.gameObject != other.gameObject &&
            other.CompareTag("Player"))
        {
            isTriggered = true;
            otherPlayer = otherObject.GetComponent<Player>();
        }

        if (other.CompareTag("MovingPlatform"))
        {
            movingPlatform = otherObject.GetComponent<MovingPlatform>();
            isOnMovingPlatform = true;
        }

        if (other.CompareTag("Ground") || other.CompareTag("MovingPlatform")) isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (transform.parent.GetComponent<Player>().isActive && transform.parent.gameObject != other.gameObject &&
            other.CompareTag("Player"))
            isTriggered = false;
        if (other.CompareTag("Ground") || other.CompareTag("MovingPlatform"))
            isGrounded = false;
        if (other.CompareTag("MovingPlatform")) isOnMovingPlatform = false;
    }

    private bool IsValidCollision(Collider2D other)
    {
        return parentPlayer.isActive && transform.parent.gameObject != other.gameObject && other.CompareTag("Player");
    }
}