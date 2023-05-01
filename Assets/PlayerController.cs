using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // this is the camera and the player
    public Camera sceneCamera;
    public Rigidbody2D body;

    // referencing the script for the weapon
    public Weapon weapon;

    // this is the movement and the mouse position
    private Vector2 moveDirection;
    private Vector2 mousePosition;

    // this is x and y
    public float x;
    public float y;
    
    // this is the speed limiter and the run speed
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
        // this is getting the inputs from the player
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // this is the attack button
        // when the user clicks the left mouse button, the weapon script will fire a bullet
        if (Input.GetMouseButtonDown(0))
        {
            weapon.FireBullet();
        }

        // this is the movement and the camera movement
        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {
        // this is the actual movement with runSpeed modifiers
        body.velocity = new Vector2(moveDirection.x * runSpeed, moveDirection.y * runSpeed);

        // this is so that the player looks at the mouse
        Vector2 lookDirection = mousePosition - body.position;
        // calculate angle to rotate the player
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        body.rotation = angle;
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