using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public void FireBullet()
    {
        Instantiate(getBulletPrefab(), getFirePoint().position, getFirePoint().rotation);
    }

    public GameObject getBulletPrefab()
    {
        return bulletPrefab;
    }

    public Transform getFirePoint()
    {
        return firePoint;
    }
}
