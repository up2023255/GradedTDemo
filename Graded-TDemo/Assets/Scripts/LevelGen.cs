using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    enum gridSpace {empty, floor, wall};
    gridSpace[,] grid;
    int roomH, roomW;
    Vector2 roomSizeWorldUnits = new Vector2(30, 30);
    float worldUnitsInOneGridCell = 1;
    struct walk
    {
        public Vector2 direction;
        public Vector2 position;
    }

    List<walk> walks;
    float chwalkChangeDirection = 0.5f, chWalkSpawn = 0.05f;
    float chWalkDestroy = 0.05f;
    int walksMax = 10;
    float fillPercent = 1.0f;
    public GameObject wall, floor;

    void Start()
    {
        Setup();
        CreateFloor();
        CreateWalls();
        RemoveSingleWalls();
        SpawnLevel();
    }

    Vector2 RandomDirection()
    {
        //Random int Picked form 0-3
        int chose = Mathf.FloorToInt(Random.value * 3.99f);
        //chose a direction
        switch (chose)
        {
            case 0:
                return Vector2.down;
            case 1:
                return Vector2.left;
            case 2:
                return Vector2.up;
            default:
                return Vector2.right;
        }
    }

    int FloorNumber()
    {
        int num = 0;
        foreach (gridSpace space in grid)
        {
            if (space == gridSpace.floor)
            {
                num++;
            }
        }
        return num;
    }

    void Spawn(float x, float y, GameObject Obj)
    {
        // position 
        Vector2 offset = roomSizeWorldUnits / 2.0f;
        Vector2 pos = new Vector2(x, y) * worldUnitsInOneGridCell - offset;
        //Object spawn
        Instantiate(Obj, pos, Quaternion.identity);
    }

    void Setup()
    {
        // Grid finds size
        roomH = Mathf.RoundToInt(roomSizeWorldUnits.x / worldUnitsInOneGridCell);
        roomW = Mathf.RoundToInt(roomSizeWorldUnits.y / worldUnitsInOneGridCell);
        //Grid creation
        grid = new gridSpace[roomW, roomH];
        //Default grid set
        for (int x = 0; x < roomW-1;x++)
        {
            for (int y = 0; y < roomH-1; y++)
            {
                //Every cell made empty
                grid[x, y] = gridSpace.empty;
            }
        }
        //First walk set
        walks = new List<walk>();
        //walk created 
        walk newWalk = new walk();
        newWalk.direction = RandomDirection();
        //Grid center found
        Vector2 spawnPosition = new Vector2(Mathf.RoundToInt(roomW / 2.0f), Mathf.RoundToInt(roomH / 2.0f));
        newWalk.position = spawnPosition;
        //Walk added to list
        walks.Add(newWalk);

    }

    void CreateFloor()
    {
        int loop = 0;
        do
        {
            //Floor creation 
            foreach (walk mywalk in walks)
            {
                grid[(int)mywalk.position.x,(int)mywalk.position.y] = gridSpace.floor;
            }

            //Destroy walk : chance
            int checksNumber = walks.Count;
            for (int j = 0; j < checksNumber; j++)
            {
                //if its not the only one. and at a low chance
                if (Random.value < chWalkDestroy && walks.Count > 1)
                {
                    walks.RemoveAt(j);
                    break; // Destroy one per loop
                }
            }

            //Pick new direction
            for (int j = 0; j < walks.Count; j++)
            {
                if (Random.value < chwalkChangeDirection)
                {
                    walk walkThis = walks[j];
                    walkThis.direction = RandomDirection();
                    walks[j] = walkThis;
                }
            }

            //Spawn new walk chance
            checksNumber = walks.Count;
            for (int j = 0; j < checksNumber; j++)
            {
                if (Random.value < chWalkSpawn && walks.Count < walksMax)
                {
                    //walk creation
                    walk newWalk = new walk();
                    newWalk.direction = RandomDirection();
                    newWalk.position = walks[j].position;
                    walks.Add(newWalk);
                }
            }

            //walk movement 
            for (int j = 0; j < walks.Count; j++)
            {
                walk walkThis = walks[j];
                walkThis.position += walkThis.direction;
                walks[j] = walkThis;
            }

            //Boarder avoided
            for (int j = 0; j < walks.Count; j++)
            {
                walk Theywalk = walks[j];
                //Adds a clamp/limit on the space they have
                Theywalk.position.x = Mathf.Clamp(Theywalk.position.x, 1, roomW-2);
                Theywalk.position.y = Mathf.Clamp(Theywalk.position.y, 1, roomH-2);
                walks[j] = Theywalk;
            }

            //ending the loop
            if ((float)FloorNumber() / (float)grid.Length > fillPercent)
            {
                break;
            }
        } while (loop < 10000);
    }

    void CreateWalls()
    {
        //Loop through every grid space
        for (int x = 0; x < roomW-1; x++)
        {
            for (int y = 0; y < roomH-1; y++)
            {
                //Checks to see if floor is there and works around it
                if (grid[x,y] == gridSpace.floor)
                {
                    //if space around = empty place wall
                    if (grid[x,y+1] == gridSpace.empty)
                    {
                        grid[x, y + 1] = gridSpace.wall;
                    }
                    if (grid[x, y-1] == gridSpace.empty)
                    {
                        grid[x, y - 1] = gridSpace.wall;
                    }
                    if (grid[x + 1, y] == gridSpace.empty)
                    {
                        grid[x + 1, y] = gridSpace.wall;
                    }
                    if (grid[x-1, y] == gridSpace.empty)
                    {
                        grid[x - 1, y] = gridSpace.wall;
                    }
                }
            }
        }
    }

    void RemoveSingleWalls()
    {

    }

    void SpawnLevel()
    {
        for (int x = 0; x < roomW; x++)
        {
            for (int y = 0; y < roomH; y++)
            {
                switch (grid[x,y])
                {
                    case gridSpace.empty:
                        break;
                    case gridSpace.floor:
                        Spawn(x,y,floor);
                        break;
                    case gridSpace.wall:
                        Spawn(x,y,wall);
                        break;
                }
            }
        }
    }
}
