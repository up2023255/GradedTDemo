using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflictDamage : MonoBehaviour
{
    public float DMG;
    public float wait;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            if (collision.GetComponent<DamageEnemy>() != null)
            {
                collision.GetComponent<DamageEnemy>().DealDamage(DMG);
                Destroy(gameObject);
            }
            //Destroy(gameObject, wait);
        }
        Destroy(gameObject, wait);
    }
}
