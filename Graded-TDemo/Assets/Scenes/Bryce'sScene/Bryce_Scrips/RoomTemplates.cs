using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
       public GameObject[] TopRoom;
       public GameObject[] BottomRoom;
       public GameObject[] LeftRoom;
       public GameObject[] RightRoom;
       public GameObject CorridorTop;
       public GameObject CorridorLeft;
       public GameObject CorridorRight;
       public GameObject CorridorBottom;


       public GameObject ClosedRoom;

       public List<GameObject> Rooms;

    public float waitTime;
    private bool BossSpawned;
    public GameObject boss;

    void update()
    {
        if(waitTime <= 0 && BossSpawned == false)
        {
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (i == Rooms.Count-1)
                {
                    Instantiate(boss, Rooms[i].transform.position, Quaternion.identity);
                    BossSpawned = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
