using System;
using UnityEngine;

public class PlayerController : Entity
{
    public Animator animator;
    public float speed = 3f;

    public float jumpForce = 20f;
    private bool isFacingRight;

    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        var direction = Input.GetAxis("Horizontal");
        animator.SetFloat("HorizontalMove", Math.Abs(direction));
        transform.position += new Vector3(direction, 0, 0) * (speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && Math.Abs(rigidbody.velocity.y) < 1e-6)
            rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

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