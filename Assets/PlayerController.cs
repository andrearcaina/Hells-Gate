using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;

    private Vector2 moveDirection;

    public float x;
    public float y;
    
    public float speedLimiter = 0.7f;
    public float runSpeed = 20.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    // FixedUpdate should handle physics, since it is not needed every frame
    private void FixedUpdate() 
    {
        Move();
    }

    // process inputs
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        body.velocity = new Vector2(moveDirection.x * runSpeed, moveDirection.y * runSpeed);
    }

    // collision detection
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Wall"){
            x = 0;
            y = 0;
        }
    }
}