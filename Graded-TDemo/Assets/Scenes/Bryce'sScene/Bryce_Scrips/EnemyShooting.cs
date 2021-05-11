using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform player;
    public float minDamage;
    public float maxDamage;
    public float force;
    private float wait;

    void Update()
    {
        ShootPlayer();
    }

    void ShootPlayer()
    {
      if (Time.time > wait)
      {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = player.transform.position * force;
            bullet.GetComponent<EnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
            wait += Time.time;
      }
    }
}




//Vector2 myPos = transform.position;
//Vector2 targetPos = player.transform.position;
//Vector2 direction = (targetPos - myPos).normalized;
//bullet.GetComponent<Rigidbody2D>().velocity = direction * force;
//bullet.GetComponent<EnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
//wait = 5f;
//Destroy(projectile, 4f);
