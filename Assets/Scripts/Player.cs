using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public PenguinNames penguinName;
    public PlayerController controller;

    public bool isActive;
    private Inventory inventory;

    private PlayerTrigger playerTrigger;


    // Start is called before the first frame update
    private void Start()
    {
        playerTrigger = transform.GetChild(0).GetComponent<PlayerTrigger>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isActive && playerTrigger.isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            playerTrigger.gameObject.SetActive(false);
            isActive = false;
            playerTrigger.otherPlayer.isActive = true;
            playerTrigger.gameObject.SetActive(true);
        }

        animator.SetBool("IsActiveAndMoving", isActive && controller.isMoving);
        controller.enabled = isActive;
    }
}