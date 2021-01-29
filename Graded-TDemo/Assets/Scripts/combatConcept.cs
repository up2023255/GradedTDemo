using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatConcept : MonoBehaviour {

    private Animator anim;

    public Transform attackPoint;
    public float attackRange = 1.0f;
    public LayerMask enemyLayers;
    public int damage = 5;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Attack();
        }
    }

    void Attack(){
        anim.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }


    }

    void OnDrawGizmosSelected() {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}