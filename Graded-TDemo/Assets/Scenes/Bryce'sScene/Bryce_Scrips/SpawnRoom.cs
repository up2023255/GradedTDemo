using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
public
    int Opening;

    private
        int rand;
        RoomTemplates templates;
        bool Isthere = false;


    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn" , 0.1f);
    }

    
    // Update is called once per frame
    void Spawn()
    {
        if (Isthere == false)
        {
            if (Opening == 1)
            {
                // A room with bottom door spawns
                rand = Random.Range(0, templates.BottomRoom.Length);
                Instantiate(templates.BottomRoom[rand], transform.position, Quaternion.identity);
            }
            else if (Opening == 2)
            {
                // A room with Top door spawns
                rand = Random.Range(0, templates.TopRoom.Length);
                Instantiate(templates.TopRoom[rand], transform.position, Quaternion.identity);
            }
            else if (Opening == 3)
            {
                // A room with left door spawns
                rand = Random.Range(0, templates.LeftRoom.Length);
                Instantiate(templates.LeftRoom[rand], transform.position, Quaternion.identity);
            }
            else if (Opening == 4)
            {
                // A room with right door spawns
                rand = Random.Range(0, templates.RightRoom.Length);
                Instantiate(templates.RightRoom[rand], transform.position, Quaternion.identity);
            }
          
            Isthere = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint") && other.GetComponent<SpawnRoom>().Isthere == true)
        {
            Destroy(gameObject);
        }
    }
}
