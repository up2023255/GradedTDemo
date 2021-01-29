using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRooms : MonoBehaviour
{
    private RoomTemplates Templates;

    // Start is called before the first frame update
    void Start()
    {
        Templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Templates.Rooms.Add(this.gameObject);
    }

   
}
