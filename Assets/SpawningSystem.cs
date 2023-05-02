using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float radius;
    public float interval;
    public GameObject Player;
    float timer;
    Vector3 bufferRadius = new Vector3(10,10,10);
    // Start is called before the first frame update
    void Start()
    {
        // find the player object
        GameObject Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // add seconds to the timer
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            // spawn the object, then reset timer
            SpawnObject();
            timer = 0;
        }
    }

    void SpawnObject()
    {
        // get transform of player object
        Transform playerTransform = Player.transform;
        // calculate a random position in a sphere around the player
        Vector3 randomPosition = (playerTransform.position + bufferRadius) + UnityEngine.Random.insideUnitSphere * radius;
        // create the enemy object
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }
}
