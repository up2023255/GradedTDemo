using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
public
    int Opening;
    float waittime = 4f;

private
      int rand;
      RoomTemplates templates;
      bool Isthere = false;

    private void Start()
    {
        Destroy(gameObject, waittime);
        // Sets template to the list of rooms declared in "RoomTemplates"
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (Isthere == false)
        {
            if (Opening == 1)
            {
                //A room with bottom door spawns
                rand = Random.Range(0, templates.BottomRoom.Length);
                Instantiate(templates.BottomRoom[rand], transform.position, templates.BottomRoom[rand].transform.rotation);
            }
            else if (Opening == 2)
            {
                // A room with Top door spawns
                rand = Random.Range(0, templates.TopRoom.Length);
                Instantiate(templates.TopRoom[rand], transform.position, templates.TopRoom[rand].transform.rotation);
            }
            else if (Opening == 3)
            {
                // A room with left door spawns
                rand = Random.Range(0, templates.LeftRoom.Length);
                Instantiate(templates.LeftRoom[rand], transform.position, templates.LeftRoom[rand].transform.rotation);
            }
            else if (Opening == 4)
            {
                // A room with right door spawns
                rand = Random.Range(0, templates.RightRoom.Length);
                Instantiate(templates.RightRoom[rand], transform.position, templates.RightRoom[rand].transform.rotation);

            }
            Isthere = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<SpawnRoom>().Isthere == false && Isthere == false)
        {
            Instantiate(templates.ClosedRoom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        Isthere = true;
    }
}