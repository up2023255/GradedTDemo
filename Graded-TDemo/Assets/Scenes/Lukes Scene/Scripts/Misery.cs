using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misery : MonoBehaviour
{
    private Transform Player;
    public int MoveSpeed = 10;
    public int MaxDist = 1;
    public int MinDist = 1;

    //Attack variables
    public int attackDMG;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;

    private Animator anim;
    private Rigidbody2D rb;

    bool isSlamming = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        GameObject player = GameObject.Find("Player");
        Player = player.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, Player.position) >= MinDist && !isSlamming)
        {

            transform.position = Vector2.MoveTowards(transform.position, Player.position, MoveSpeed * Time.deltaTime);
            anim.SetBool("moving", true);
            anim.SetBool("canAttack", false);

            if (Player.position.x < transform.position.x)
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
            }
            if (Player.position.x > transform.position.x)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }

            if (Vector2.Distance(transform.position, Player.position) <= MaxDist)
            {
                StartCoroutine("Slam");
                anim.SetBool("moving", false);
            }
        }
    }

    public void Attack()
    {
        Collider2D[] playerHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        foreach (Collider2D player in playerHit)
        {
            player.GetComponent<Player>().TakeDamage(attackDMG);
        }
    }

    public IEnumerator Slam()
    {
        isSlamming = true;

        anim.SetBool("canAttack", true);
        yield return new WaitForSeconds(2f);

        isSlamming = false;
    }
}
