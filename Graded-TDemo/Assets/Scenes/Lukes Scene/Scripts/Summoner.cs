using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : MonoBehaviour
{
    public GameObject skeletonPrefab;

    private Animator mainAnim;
    private Animator subAnim;

    public Transform summonSpot;

    // Start is called before the first frame update
    void Start()
    {
        mainAnim = this.GetComponent<Animator>();
        subAnim = GetComponentInChildren<Animator>();
        summonSpot = this.gameObject.transform.GetChild(0);
    }

   
    void Update()
    {
        InvokeRepeating("Summon", 3f, 3f);
    }

    public IEnumerator Summon()
    {
        subAnim.Play("Summon");
        yield return new WaitForSeconds(0.5f);
        Instantiate(skeletonPrefab, summonSpot, Quaternion.identity);
    }
}
