using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    Vector2 mapSize = new Vector2(4, 4);
    Room[,] _rooms;
    List<Vector2> usedPos = new List<Vector2>();
    int sizeOfGridX, sizeOfGridY, roomNum = 20;
    public GameObject roomWhiteObj;

    void Start()
    { 
        if (roomNum >= (mapSize.x * 2) * (mapSize.y * 2))
        {
            roomNum = Mathf.RoundToInt((mapSize.x * 2) * (mapSize.y * 2));
        }
        sizeOfGridX = Mathf.RoundToInt(mapSize.x);
        sizeOfGridY = Mathf.RoundToInt(mapSize.y);

        CreateRooms();
        SetRoomDoors();
        DrawMap();
    }

    void CreateRooms()
    {
        _rooms = new Room[sizeOfGridX * 2, sizeOfGridY * 2];
        _rooms[sizeOfGridX, sizeOfGridY] = new Room(Vector2.zero, 1);
    }

}
