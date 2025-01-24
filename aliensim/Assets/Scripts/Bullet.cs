using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 25; // Damage dealt by the bullet
    public float lifetime = 2f; // Bullet lifetime

    float lifeTick;

    private void Update()
    {
        lifeTick += Time.deltaTime;

        if (lifeTick > lifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the bullet hits an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HealthSystem enemyHealth = collision.gameObject.GetComponent<HealthSystem>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(damage);
            }
             // Destroy the bullet on impact
        }
        Destroy(gameObject);
    }
}