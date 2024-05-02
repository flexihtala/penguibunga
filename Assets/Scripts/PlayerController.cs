using System;
using UnityEngine;

public class PlayerController : Entity
{
    public bool isMoving;
    public float speed = 3f;

    public float jumpForce = 20f;
    private bool isFacingRight;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        var direction = Input.GetAxis("Horizontal");
        isMoving = Math.Abs(direction) > 0.01;
        transform.position += new Vector3(direction, 0, 0) * (speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && Math.Abs(rb.velocity.y) < 1e-6)
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        DefineFacing();
    }

    public override void Die()
    {
        Debug.Log("ты бы уже сдох писна, но пока живи");
        //Destroy(gameObject);
    }

    public override void ReceiveDamage()
    {
        Die();
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