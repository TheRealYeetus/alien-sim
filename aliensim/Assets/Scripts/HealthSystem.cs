using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] bool destroyOnDeath = false;
    [SerializeField] GameObject bloodEffect;

    public float hp = 1000;
    [SerializeField] float maxHp = 1000;
    

    public void Damage(float damage)
    {
        if (damage > hp)
        {
            hp = 0;
        }
        else
        {
            hp -= damage;
        }

        if (hp <= 0)
        {
            Death();

            if (!destroyOnDeath)
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void Death()
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
    }
}
