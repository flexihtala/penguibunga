using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public PenguinNames penguinName;
    public PlayerController controller;

    public bool isActive;

    private PlayerTrigger playerTrigger;
    private AudioManager audioManager;


    // Start is called before the first frame update
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        playerTrigger = transform.GetChild(0).GetComponent<PlayerTrigger>();
    }

    private void Awake()
    {
        if (isActive)
            GameState.ActivePlayer = this;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isActive)
            GameState.ActivePlayer = this;
        if (isActive && playerTrigger.isTriggered && Input.GetKeyDown(KeyCode.F))
        {
            playerTrigger.gameObject.SetActive(false);
            isActive = false;
            playerTrigger.otherPlayer.isActive = true;
            playerTrigger.gameObject.SetActive(true);
        }

        animator.SetBool("IsActiveAndMoving", isActive && controller.isMoving);
        controller.enabled = isActive;
    }

    public void Die(Player unit)
    {
        audioManager.PlaySFX(audioManager.death);
        unit.gameObject.transform.position = GameState.PlatformerSpawn;
    }
}