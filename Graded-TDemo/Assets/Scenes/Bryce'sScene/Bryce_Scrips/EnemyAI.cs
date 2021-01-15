﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float movespeed = 6f;
    public float RoamSpeed = 6f;

    private enum State
    {
        Roam,
        ChaseTarget,
    }

    private Vector2 RandomPos;
    private Vector2 StartPos;
    private Vector2 RoamPos;
    private Vector2 movement;
    private State state;
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
        state = State.Roam;
    }

    //Chassing the player AI:
    void Start()
    {    
        //RoamPos = Roaming();

        rb = GetComponent<Rigidbody2D>();
        StartPos = transform.position;
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
        ChaseTarget(movement);
        Roam();
    }
    void ChaseTarget(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }
    //Roaming - Kinda Wack at the moment 
    void Roam()
    {
        rb.MovePosition((Vector2)transform.position + (RanDirection() * RoamSpeed * Time.deltaTime));
    }

    private void TargetFound()
    {
        float Range = 50f;
        if (Vector2.Distance(transform.position, player.position) < Range)
        {
            state = State.ChaseTarget;
        }
    }


}
