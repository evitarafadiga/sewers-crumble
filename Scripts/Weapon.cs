using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform player;

    public GameObject bulletPrefab;

    public float bulletForce = 2f;

    private Vector3 direction;
    private float angle;

    void Update()
    {
        direction = player.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x);
        direction.Normalize();
    }

    public void OnTriggerStay2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.rotation = angle;
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);

    }
}
