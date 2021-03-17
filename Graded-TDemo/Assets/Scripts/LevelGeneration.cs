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
        usedPos.Insert(0, Vector2.zero);
        Vector2 checkPos = Vector2.zero;

        float compareRandom = 0.2f, compareStartRandom = 0.2f, compareEndRandom = 0.2f;
        
        for (int i = 0; i < roomNum - 1; i++)
        {
            float percRandom = ((float)i) / (((float)roomNum - 1));
            compareRandom = Mathf.Lerp(compareStartRandom, compareEndRandom, percRandom);

            checkPos = NewPosition();

            if (NumOfNeighbors(checkPos, usedPos) > 1 && Random.value > compareRandom)
            {
                int iterations = 0;
                do
                {
                    checkPos = SelectNewPositon();
                    iterations++;
                } while (NumOfNeighbors(checkPos, usedPos) > 1 && iterations < 100);
                if (iterations >= 50)
                    print("error: could not create with fewer neighbors than : " + NumOfNeighbors(checkPos, usedPos));
            }
            _rooms[(int)checkPos.x + sizeOfGridX, (int)checkPos.y + sizeOfGridY] = new Room(checkPos, 0);
            usedPos.Insert(0, checkPos);
        }
    }

    Vector2 NewPosition()
    {
        int x = 0, y = 0;
        Vector2 checkingPos = Vector2.zero;

        do
        {
            int index = Mathf.RoundToInt(Random.value * (usedPos.Count - 1));
            x = (int)usedPos[index].x;
            y = (int)usedPos[index].y;
            bool updown = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);

            if (updown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector2(x, y);
        } while (usedPos.Contains(checkingPos) || x >= sizeOfGridX || x < -sizeOfGridX || y >= sizeOfGridY || y < -sizeOfGridY);
        return checkingPos;
    }

    Vector2 SelectNewPositon()
    {
        int index = 0, inc = 0;
        int x = 0, y = 0;
        Vector2 posCheck = Vector2.zero;

        do
        {
            inc = 0;
            do
            {
                index = Mathf.RoundToInt(Random.value * (usedPos.Count - 1));
                inc++;
            } while (NumOfNeighbors(usedPos[index], usedPos) > 1 && inc < 100);

            x = (int)usedPos[index].x;
            y = (int)usedPos[index].y;
            bool upDown = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);
            if (upDown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            posCheck = new Vector2(x, y);
        } while (usedPos.Contains(posCheck) || x >= sizeOfGridX || x < -sizeOfGridX || y >= sizeOfGridY || y < -sizeOfGridY);
        if (inc >= 100)
        {
            print("Error: could not find position with only one neighbor");
        }
        return posCheck;
    }

    int NumOfNeighbors(Vector2 checkingPos, List<Vector2> usedPositions)
    {
        int ret = 0;
        if (usedPositions.Contains(checkingPos + Vector2.right))
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPos + Vector2.left));
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPos + Vector2.up))
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPos + Vector2.down))
        {
            ret++;
        }
        return ret;
    }

    void SetRoomDoors()
    {
        for (int x = 0; x < ((sizeOfGridX * 2)); x++)
        {
            for (int y = 0; y < ((sizeOfGridY * 2)); y++)
            {
                if (_rooms[x, y] == null)
                {
                    continue;
                }
                Vector2 gridPos = new Vector2(x, y);
                if (y - 1 < 0)
                {
                    _rooms[x, y].doorB = false;
                }
                else
                {
                    _rooms[x, y].doorB = (_rooms[x, y - 1] != null);
                }
                if (y + 1 >= sizeOfGridY * 2)
                {
                    _rooms[x, y].doorT = false;
                }
                else
                {
                    _rooms[x, y].doorT = (_rooms[x, y + 1] != null);
                }
                if (x - 1 < 0)
                {
                    _rooms[x, y].doorL = false;
                }
                else
                {
                    _rooms[x, y].doorL = (_rooms[x - 1, y] != null);
                }
                if (x + 1 >= sizeOfGridX * 2)
                {
                    _rooms[x, y].doorR = false;
                }
                else
                {
                    _rooms[x, y].doorR = (_rooms[x + 1, y] != null);
                }
            }
        }
    }

    void DrawMap()
    {
        foreach (Room room in _rooms)
        {
            if (room == null)
            {
                continue;
            }
            Vector2 drawPos = room.gridpos;
            drawPos.x *= 16;
            drawPos.y *= 8;
            MapSpriteSelector mapper = Object.Instantiate(roomWhiteObj, drawPos, Quaternion.identity).GetComponent<MapSpriteSelector>();
            mapper.type = room.type;
            mapper.up = room.doorT;
            mapper.down = room.doorB;
            mapper.right = room.doorR;
            mapper.left = room.doorL;
        }
    }

}
