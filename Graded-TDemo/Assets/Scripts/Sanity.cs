using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanity : MonoBehaviour
{

    bool sanity;
    private GameObject[] sanityEntities;

    void Start()
    {
        sanityEntities = GameObject.FindGameObjectsWithTag("Insane");
        GameObject player = GameObject.Find("Player") as GameObject;
        player.GetComponent<Player>();
       
    }

    void Update()
    {
        
        sanity = Player.sane;
        if (sanity == false)
        {
            foreach (GameObject gameObject in sanityEntities)
            {
                gameObject.SetActive(true);
            }
        }
        if(sanity == true)
        {
            foreach (GameObject gameObject in sanityEntities)
            {
                gameObject.SetActive(false);
            }
        }
    }
}