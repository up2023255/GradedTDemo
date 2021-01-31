using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanity : MonoBehaviour
{

    bool sanity;

    void Start()
    {
        GameObject player = GameObject.Find("Player") as GameObject;
        player.GetComponent<Player>();
       
    }

    void Update()
    {
        GameObject[] sanityEntities = GameObject.FindGameObjectsWithTag("Insane");
        sanity = Player.sane;
        if (sanity == false)
        {
            foreach (GameObject gameObject in sanityEntities)
            {
                gameObject.SetActive(true);
                Debug.Log("On");
            }
        }
        if(sanity == true)
        {
            foreach (GameObject gameObject in sanityEntities)
            {
                gameObject.SetActive(false);
                Debug.Log("Off");
            }
        }
    }
}