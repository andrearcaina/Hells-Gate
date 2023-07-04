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

    // this is the shoot interval
    public float shootInterval = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
        // game loop
        InvokeRepeating("ShootAtEnemy", 0, shootInterval);
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

    private void ShootAtEnemy()
    {
        // gets all the enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // initialize the closest enemy and the closest distance
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        // find the closest enemy
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestEnemy = enemy; // this is the new closest enemy
                closestDistance = distance; // this is the new closest distance (to keep track of the closest enemy)
            }
        }

        // shoot at the enemy if there is one
        if (closestEnemy != null)
        {
            // rotate the player to face the enemy
            Vector3 lookDirection = closestEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

            // this is the rotation of the player
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;

            // this is the shooting of bullet
            weapon.FireBullet();
        }
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