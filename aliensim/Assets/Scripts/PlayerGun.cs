using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab
    public Transform firePoint;     // The point where bullets spawn
    public float bulletSpeed = 20f; // Speed of the bullet
    public float fireRate = 0.2f;   // Time between shots

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime) // Left mouse button to shoot
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Spawn the bullet at the fire point
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Add velocity to the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = -firePoint.up * bulletSpeed;

        Debug.Log("Bullet fired!");
    }
}
