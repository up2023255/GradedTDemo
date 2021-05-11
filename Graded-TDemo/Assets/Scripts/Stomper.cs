using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    private GameObject player;
    public int MoveSpeed = 10;

    private bool isLeaping = false;
    
    private Animator anim;
    private Rigidbody2D rb;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>().gameObject;
        StartCoroutine("Leap");
    }

    void Update()
    {
        Vector2 targetPos = player.transform.position;
        if (isLeaping)
        transform.position = Vector2.MoveTowards(transform.position, targetPos, MoveSpeed * Time.deltaTime);

        if (targetPos.x < transform.position.x)
        {
            transform.localEulerAngles = new Vector2(0, 180);
        }
        if (targetPos.x > transform.position.x)
        {
            transform.localEulerAngles = new Vector2(0, 0);
        }
    }

    public IEnumerator Leap()
    {
        anim.SetTrigger("Attack");
        isLeaping = true;
        
        yield return new WaitForSeconds(1f);
        isLeaping = false;

        yield return new WaitForSeconds(0.5f);
        StartCoroutine("Leap");

    }
}
