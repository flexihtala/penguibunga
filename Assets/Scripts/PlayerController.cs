using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isMoving;
    public float speed = 3f;

    public float jumpForce = 20f;
    private bool isFacingRight;

    private Rigidbody2D rb;
    private PlayerTrigger playerTrigger;
    private bool doubleJump;
    private PenguinNames penguinName;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTrigger = transform.GetChild(0).GetComponent<PlayerTrigger>();
        penguinName = gameObject.GetComponent<Player>().penguinName;
    }

    // Update is called once per frame
    private void Update()
    {
        var direction = Input.GetAxis("Horizontal");
        isMoving = Math.Abs(direction) > 0.01;
        transform.position += new Vector3(direction, 0, 0) * (speed * Time.deltaTime);

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
        playerScale.x *= -1;
        transform.localScale = playerScale;

        isFacingRight = !isFacingRight;
    }
}