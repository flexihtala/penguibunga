using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public float jumpForce = 20f;

    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var direction = Input.GetAxis("Horizontal");
        transform.position += new Vector3(direction, 0, 0) * (speed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.Space) && Math.Abs(rigidbody.velocity.y) < 1e-6)
            rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
