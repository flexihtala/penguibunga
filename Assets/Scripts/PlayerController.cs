using System;
using UnityEngine;

public class PlayerController : Entity
{
    public float speed = 5f;

    public float jumpForce = 20f;

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
        transform.position += new Vector3(direction, 0, 0) * (speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && Math.Abs(rigidbody.velocity.y) < 1e-6)
            rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
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
}