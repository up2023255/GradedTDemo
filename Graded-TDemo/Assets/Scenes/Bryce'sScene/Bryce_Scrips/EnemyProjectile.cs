    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.tag != "Enemy")
        {
            if (collision.GetComponent<Player>() != null)
            {
                collision.GetComponent<Player>().TakeDamage((int) damage);
            }

            Destroy(gameObject);
        }
    }
}
