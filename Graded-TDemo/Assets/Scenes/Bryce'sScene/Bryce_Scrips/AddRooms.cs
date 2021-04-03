using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRooms : MonoBehaviour
{
    private RoomTemplates Templates;

    [Header("Varification")]
    public Collider2D[] colliders;
    public float radius;


    // Start is called before the first frame update
    void Start()
    {
        Templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Templates.Rooms.Add(this.gameObject);
    }

   void update()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, radius);
    }
}
