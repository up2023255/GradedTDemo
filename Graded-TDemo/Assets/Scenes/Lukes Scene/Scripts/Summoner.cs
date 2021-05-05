using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : MonoBehaviour
{
    public GameObject skeletonPrefab;

    private Animator mainAnim;
    private Rigidbody2D rb;

    bool hasTeleported;
    private int dangerZone = 2;
    private Transform Player;

    void Start()
    {
        mainAnim = this.GetComponent<Animator>();
        StartCoroutine(Summon());

        rb = this.GetComponent<Rigidbody2D>();

        GameObject player = GameObject.Find("Player");
        Player = player.transform;
    }


    void Update()
    {
        if (Vector2.Distance(transform.position, Player.position) <= dangerZone && !hasTeleported)
        {
            StartCoroutine("Appear");
        }
    }

    public IEnumerator Summon()
    {
        mainAnim.SetTrigger("Summon");
        yield return new WaitForSeconds(1.5f);
        Instantiate(skeletonPrefab, transform.position, Quaternion.identity);
        Debug.Log("Summon");

        yield return new WaitForSeconds(2f);
        StartCoroutine("Summon");
    }

    public IEnumerator Appear()
    {
        hasTeleported = true;

        mainAnim.Play("Disappear");
        yield return new WaitForSeconds(1f);

        mainAnim.SetTrigger("Appear");
        transform.position = new Vector2(transform.position.x + 5, transform.position.y);
        

    }
}
