using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflictDamage : MonoBehaviour
{
    public float DMG;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            if (collision.GetComponent<DamageEnemy>() != null)
            {
                collision.GetComponent<DamageEnemy>().DealDamage(DMG);
            }
            Destroy(gameObject);
        }
    }
}
