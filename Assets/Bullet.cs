using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletDamage;
    public float destroyTime;

    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
            other.gameObject.GetComponent<EnemyBehaviour>().takeDamage(bulletDamage);
            Destroy(gameObject);
            break;
        }
    }
}
