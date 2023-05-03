using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Transform Target;
    private GameObject player;
    public float speed;
    public float health;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Target = player.transform;
    }
    // Update is called once per frame
    void Update()
    {
        // Calculate distance to move
        float step = speed * Time.deltaTime;
        // Move the current position closer to the target by step amount
        transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
    }

    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
