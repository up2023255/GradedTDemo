using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSnapCamear : MonoBehaviour
{
    public Transform target;
    
    public float speed;

    void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            transform.Translate(11.75f, 0f, 0f);
        }
    }
   /* public void moveCameraLeft ()
    {
        transform.Translate(12f, 0f, 0f);
    }*/
}
