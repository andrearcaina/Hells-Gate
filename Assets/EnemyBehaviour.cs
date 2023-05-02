using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform Target;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        // Calculate distance to move
        float step = speed * Time.deltaTime;
        // Move the current position closer to the target by step amount
        transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
    }
}
