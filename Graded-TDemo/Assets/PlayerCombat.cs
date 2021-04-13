using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //Animation variables 
    public Animator animator;

    //Attack variables
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDMG = 40;

    //Enemy define variables
    public LayerMask enemyLayers;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    private void Attack()
    {
     //Play attack animation
        animator.SetTrigger("Attack");
     
     //Detect enemies in a range of attack
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(attackPoint.position, enemyLayers, enemyLayers);
     
     //Deal Damage
        foreach (Collider2D enemy in enemyHit)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDMG);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
