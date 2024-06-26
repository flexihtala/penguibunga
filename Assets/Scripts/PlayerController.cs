using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isMoving;
    public float speed = 3f;

    public float jumpForce = 20f;
    public float dashForce = 20f;
    public bool IsGameOver;

    private bool canDash = true;
    private float dashCooldown = 0.2f;
    private float dashTime = 0.2f;
    private bool doubleJump;
    private bool isDashing;
    private bool isFacingRight;
    private PenguinNames penguinName;
    private PlayerTrigger playerTrigger;
    private AudioManager audioManager;
    private Rigidbody2D rb;

    [SerializeField] private Canvas canvas;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTrigger = transform.GetChild(0).GetComponent<PlayerTrigger>();
        penguinName = gameObject.GetComponent<Player>().penguinName;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // review(27.06.2024): Я бы вообще разбил этот метод на несколько MonoBehaviour, отвечающих за Dash/Movment/Jump соответственно
    private void Update()
    {
        if (isDashing || IsGameOver)
            return;

        // review(27.06.2024): HandleDash()
        if ((Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
            && canDash && penguinName == PenguinNames.Krico
            && !playerTrigger.isGrounded)
            StartCoroutine(Dash());

        // review(27.06.2024): HandleMovement()
        var direction = Input.GetAxis("Horizontal");
        isMoving = Math.Abs(direction) > 0.01;
        // review(27.06.2024): Если не isMoving, то можно не менять позицию игрока, чтобы зря лишний раз движок не дергать
        transform.position += new Vector3(direction, 0, 0) * (speed * Time.deltaTime);

        // review(27.06.2024): HandleJump()
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerTrigger.isGrounded || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                if (penguinName == PenguinNames.Krico)
                    doubleJump = !doubleJump;
            }
        }

        if (playerTrigger.isGrounded && penguinName == PenguinNames.Krico)
            doubleJump = true;
        DefineFacing();
    }


    private void DefineFacing()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && !isFacingRight)
            Flip();

        if (Input.GetAxisRaw("Horizontal") < 0 && isFacingRight)
            Flip();
    }

    private void Flip()
    {
        var playerScale = gameObject.transform.localScale;
        var canvasScale = canvas.transform.localScale;

        playerScale.x *= -1;
        canvasScale.x *= -1;

        transform.localScale = playerScale;
        canvas.transform.localScale = canvasScale;

        isFacingRight = !isFacingRight;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        var originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        audioManager.PlaySFX(audioManager.dash);
        rb.velocity = new Vector2(-transform.localScale.x * dashForce, 0);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}