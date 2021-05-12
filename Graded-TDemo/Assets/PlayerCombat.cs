//using System;
using System.Collections;
using UnityEngine;


public class PlayerCombat : MonoBehaviour
{
    //Linking Enemy Script to Deal Damage
    DamageEnemy DamageEnemy;

    //Animation variables 
    public Animator animator;

    //Attack variables
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDMG = 40;

    //Enemy define variables
    public LayerMask enemyLayers;

    //Projectile Attack
    public GameObject projectile;
    public float minDMG;
    public float maxDMG;
    public float projectileForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShootAttack();
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
        }
    }

     IEnumerator Attack()
    {
        yield return new WaitForSeconds(1f);

        //Play attack animation
        animator.SetTrigger("Attack");
     
       //Detect enemies in a range of attack
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(attackPoint.position, enemyLayers);

        //Deal Damage
        foreach (Collider2D enemy in enemyHit)
        {
            enemy.GetComponent<DamageEnemy>().DealDamage(attackDMG);
        }
    }

    //private void Attack()
    //{
    // //Play attack animation
    //    animator.SetTrigger("Attack");
     
    // //Detect enemies in a range of attack
    //    Collider2D[] enemyHit = Physics2D.OverlapCircleAll(attackPoint.position, enemyLayers, enemyLayers);

    //    //Deal Damage
    //    foreach (Collider2D enemy in enemyHit)
    //    {
    //        enemy.GetComponent<DamageEnemy>().DealDamage(attackDMG);
    //    }
    //}

    private void ShootAttack()
    {
        GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = transform.position;
        Vector2 direction = (mousePos - myPos).normalized;
        spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
        spell.GetComponent<InflictDamage>().DMG = Random.Range(minDMG, maxDMG);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
