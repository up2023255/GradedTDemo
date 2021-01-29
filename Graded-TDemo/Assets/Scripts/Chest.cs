using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    GameObject player = GameObject.Find("Payer");
    Player thePlayer = player.GetComponent<Player>();

    private void Update()
    {
        if (thePlayer.sanity == false)
        {
            GetComponent<Renderer>().enabled = true;
        }
    }
}