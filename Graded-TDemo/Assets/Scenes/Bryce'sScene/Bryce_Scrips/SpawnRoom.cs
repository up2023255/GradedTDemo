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
      //bool Isthere = false;

    private void Start()
    {
        // Sets template to the list of rooms declared in "RoomTemplates"
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.01f);
    }

    public
    // Update is called once per frame
    void Spawn()
    {
        if (Opening == 1)
        {
            //A room with bottom door spawnsx
            rand = Random.Range(0,templates.BottomRoom.Length);
            Instantiate(templates.BottomRoom[rand], transform.position, templates.BottomRoom[rand].transform.rotation);
        }
        else if (Opening == 2)
        {
            // A room with Top door spawns
            rand = Random.Range(0,templates.TopRoom.Length);
            Instantiate(templates.TopRoom[rand], transform.position, templates.TopRoom[rand].transform.rotation);
        }
        else if (Opening == 3)
        {
               // A room with left door spawns
            rand = Random.Range(0,templates.LeftRoom.Length);
            Instantiate(templates.LeftRoom[rand], transform.position, templates.LeftRoom[rand].transform.rotation);
        }
        else if (Opening == 4)
        {
            // A room with right door spawns
            rand = Random.Range(0,templates.RightRoom.Length);
            Instantiate(templates.RightRoom[rand], transform.position, templates.RightRoom[rand].transform.rotation);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
//switch(Opening)
//{
//    case 1:
//            //A room with bottom door spawnsx
//        rand = Random.Range(0,templates.BottomRoom.Length);

//        Instantiate(templates.BottomRoom[rand], transform.position, templates.BottomRoom[rand].transform.rotation);

//        break;

//    case 2:
//            // A room with Top door spawns
//        rand = Random.Range(0,templates.TopRoom.Length);

//        Instantiate(templates.TopRoom[rand], transform.position, templates.TopRoom[rand].transform.rotation);

//        break;

//    case 3:
//           // A room with left door spawns
//        rand = Random.Range(0,templates.LeftRoom.Length);

//        Instantiate(templates.LeftRoom[rand], transform.position, templates.LeftRoom[rand].transform.rotation);

//        break;

//    case 4:
//           // A room with right door spawns
//        rand = Random.Range(0,templates.RightRoom.Length);

//        Instantiate(templates.RightRoom[rand], transform.position, templates.RightRoom[rand].transform.rotation);

//        break;
//}