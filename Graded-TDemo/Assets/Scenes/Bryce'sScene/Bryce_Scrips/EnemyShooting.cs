using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectile;
    private GameObject player;

    public float minDamage;
    public float maxDamage;
    public float force;
    public float wait;

    public Collider2D collider;

    private Animator anim;

    void Start()
    {
        StartCoroutine(ShootPlayer());
        player = FindObjectOfType<Player>().gameObject;

        anim = GetComponent<Animator>();
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(wait);
        if (player != null)
        {
            if (collider.GetComponent<Player>() != null)
            {
                anim.SetTrigger("Attack");
                yield return new WaitForSeconds(0.8f);

                GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
                Vector2 myPos = transform.position;
                Vector2 targetPos = player.transform.position;
                Vector2 direction = (targetPos - myPos).normalized;
                bullet.GetComponent<Rigidbody2D>().velocity = direction * force;
                bullet.GetComponent<EnemyProjectile>().damage = Random.Range(minDamage, maxDamage);

                StartCoroutine(ShootPlayer());
            }
        }
    }
}
