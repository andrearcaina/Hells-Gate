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
        projectile.GetComponent<Rigidbody2D>().AddForce(getFirePoint().up * getFireForce(), ForceMode2D.Impulse);
    }

    public GameObject getBulletPrefab()
    {
        return bulletPrefab;
    }

    public Transform getFirePoint()
    {
        return firePoint;
    }

    public float getFireForce()
    {
        return fireForce;
    }
}
