using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce;
    
    public void FireBullet()
    {
        GameObject projectile = Instantiate(getBulletPrefab(), getFirePoint().position, getFirePoint().rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(getFirePoint().up * fireForce, ForceMode2D.Impulse);
    }

    public GameObject getBulletPrefab()
    {
        bulletPrefab = GameObject.Find("Bullet").GetComponent<GameObject>();
        return bulletPrefab;
    }

    public Transform getFirePoint()
    {
        firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
        return firePoint;
    }
}
