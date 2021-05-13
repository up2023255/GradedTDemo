using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int MaxHealth = 100;
    public int currentHealth;
    public Transform attackPoint;
    public float attackRange = 1.0f;
    public LayerMask playerLayer;
    public int damage = 10;


    void Start() {
        currentHealth = MaxHealth;
        //RoamPos = Roaming();
        RandomPos = Random.Range(0, roamPoints.Length);
        rb = GetComponent<Rigidbody2D>();
        StartPos = transform.position;
    }

    /*void OnCollisionEnter2D()
    {
        //knockback
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach(Collider2D player in hitPlayer)
        {
            player.GetComponent<Player>().TakeDamage(damage);
        }
    }*/

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if(currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    public Transform player;
    public Transform[] roamPoints;
    public float movespeed = 6f;
    public float RoamSpeed = 6f;
    public float StartWaitTime;

    private enum State
    {
        Roam,
        ChaseTarget,
    }

    private float WaitTime;
    private int RandomPos;
    private Vector2 StartPos;
    private Vector2 RoamPos;
    private Vector2 movement;
    //private State state;
    private Rigidbody2D rb;

    public static Vector2 RanDirection()
    {
        return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
    }
    //private Vector2 Roaming()
    //{
    //    return StartPos + RanDirection() * Random.Range(10f, 50f);
    //}
    private void Awake()
    {
        //state = State.Roam;
    }

    private void Update()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        //switch (state)
        //{
        //    default:
        //    case State.Roam:
        //        rb.MovePosition((Vector2)transform.position + (RanDirection() * RoamSpeed * Time.deltaTime));
        //        break;
        //    case State.ChaseTarget:

        //        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
        //        break;

        //}
    }

    private void FixedUpdate()
    {
        //ChaseTarget(movement);
        //Roam();
    }
    void ChaseTarget(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }
    //Roaming - Kinda Wack at the moment 
    //void Roam()
    //{
    //    rb.MovePosition((Vector2)transform.position + (RanDirection() * RoamSpeed * Time.deltaTime));
    //    transform.position = Vector2.MoveTowards(transform.position, roamPoints[RandomPos].position, RoamSpeed * Time.deltaTime);

    //    float Range = 50f;
    //    if (Vector2.Distance(transform.position, roamPoints[RandomPos].position) < 0.2f)
    //    {
    //        if (WaitTime <= 0)
    //        {
    //            RandomPos = Random.Range(0, roamPoints.Length);
    //            WaitTime = StartWaitTime;
    //        }
    //        else
    //        {
    //            WaitTime -= Time.deltaTime;
    //        }
    //    }
    //}

    private void TargetFound()
    {

    }

}