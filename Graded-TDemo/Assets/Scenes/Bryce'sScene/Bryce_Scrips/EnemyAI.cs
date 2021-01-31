using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Roaming")]
    public float RoamSpeed = 6f;
    public Transform[] roamPoints;
    public float StartWaitTime;
    private float WaitTime;

    [Header("Shooting")]
    public float fireRate = 1f;
    private float Firecountdown = 0f;
    public GameObject projectile;

    [Header("Chasing")]
    public float movespeed = 6f;
    private Vector2 movement;
    public Transform player;
    public float stoppingDistance;
    public float tooClose;

    [Header("General")]
    private int RandomPos;
    private Vector2 StartPos;
    private Vector2 RoamPos;
    private Rigidbody2D rb;

    [Header("LockOnToTarget")]
    public float Range = 19f;
    private Transform Target;
    public Transform enemy_;
    public float rotSpeed = 10f;

    // Target Lock on 
    void updateTarget()
    {
        GameObject[] _player = GameObject.FindGameObjectsWithTag("Player");
        float shortestDis = Mathf.Infinity;
        GameObject Nearest = null;

        foreach (GameObject Player in _player)
        {
            float Distance = Vector2.Distance(transform.position, player.transform.position);

            if( Distance < shortestDis)
            {
                shortestDis = Distance;
                Nearest = Player;
            }
        }
        if (Nearest != null && shortestDis <= Range)
        {
            Target = Nearest.transform;
        }
        else
        {
            Target = null;
        }
    }

    // Generic code that is used in other areas and states of the enemy
    public static Vector2 RanDirection()
    {
        return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
    }
    void Start()
    {
        //RoamPos = Roaming();
        RandomPos = Random.Range(0, roamPoints.Length);
        rb = GetComponent<Rigidbody2D>();
        StartPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("updateTarget", 0f, 0.5f);
    }
    private void Update()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        // Direct's the enemy to face the palyer when in range
        Vector3 _Direction = Target.position - transform.position;
        Quaternion lookDirection = Quaternion.LookRotation(_Direction);
        Vector3 rotate = Quaternion.Lerp(enemy_.rotation, lookDirection, Time.deltaTime * rotSpeed).eulerAngles;
        enemy_.rotation = Quaternion.Euler (0f, 0f, rotate.z);

        if (Target == null)
            return;
    }


    // Activation of each enemy state -- still need to switch state automatically // If statement or Switch case  may work unsure
    private void FixedUpdate()
    {
        ChaseTarget(movement);
        //Roam();
        Shoot();
    }

    //Chassing the player AI:
    void ChaseTarget(Vector2 direction)
    {
        if(Vector2.Distance(transform.position,player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, movespeed * Time.deltaTime);
            //transform.Rotate(180f, 0f, 0f);
        }
        else if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) > tooClose)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) > tooClose)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -movespeed * Time.deltaTime);
           //transform.Rotate(180f, 0f, 0f);
        }
    }

    //Roaming - Kinda Wack at the moment: 
    void Roam()
    {
        rb.MovePosition((Vector2)transform.position + (RanDirection() * RoamSpeed * Time.deltaTime));
        transform.position = Vector2.MoveTowards(transform.position, roamPoints[RandomPos].position, RoamSpeed * Time.deltaTime);

        //float _Range = 50f;
        if (Vector2.Distance(transform.position, roamPoints[RandomPos].position) < 0.2f)
        {
            if (WaitTime <= 0)
            {
                RandomPos = Random.Range(0, roamPoints.Length);
                WaitTime = StartWaitTime;
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }
    }

    //Shooting at player:
    void Shoot()
    {
        if(Firecountdown <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            Firecountdown = 1f / fireRate;
        }
        else
        {
            Firecountdown -= Time.deltaTime;
        }
    }

}
///Descared code not currently needed (maybe usefull later unknown):
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
//private Vector2 Roaming()
//{
//    return StartPos + RanDirection() * Random.Range(10f, 50f);
//}
//private enum State
//{
//    Roam,
//    ChaseTarget,
//}
//private void Awake()
//{
//    state = State.Roam;
//}
//private State state;