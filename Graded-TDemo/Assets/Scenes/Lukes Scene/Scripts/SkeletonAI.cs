using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAI : MonoBehaviour
{
    
    private Transform Player;
    public int MoveSpeed = 10;
    public int MaxDist = 1;
    public int MinDist = 1;

    private Animator anim;
    private Rigidbody2D rb;

    //Attack variables
    public int attackDMG;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;


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

        // transform.LookAt(Player);
        
        if (Vector2.Distance(transform.position, Player.position) >= MinDist)
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
                anim.SetBool("canAttack", true);
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
}
