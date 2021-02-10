using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemies : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Inch", 1.0f, 1.0f);
    }

    void Update()
    {
        
        //InvokeRepeating("Inch", 1.0f, 50.0f);
    }

    void Inch()
    {
        target = new Vector2(player.position.x, player.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void OnTriggerEnter2d(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           //DealDamage.
        }
    }

}
