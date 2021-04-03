using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    enum gridSpace { empty, floor, wall, enemies, player};
    gridSpace[,] grid;
    int roomH, roomW;
    Vector2 roomSizeWorldUnits = new Vector2(50, 50);
    float worldUnitsInOneGridCell = 1;
    struct map
    {
        public Vector2 direction;
        public Vector2 position;
    }
    List<map> mappers;
    float chwalkChangeDirection = 0.5f, chWalkSpawn = 5.0f;
    float chWalkDestroy = 0.05f;
    int mappersMax = 50;
    float fillPercent = 0.5f;
    public GameObject Wall, Floor, Player;
    public GameObject Enemy;


    void Start()
    {
        Setup();
        CreateFloor();
        CreateWalls();
        EnemySpawnPos();
        PlayerSpawn();
        SpawnLevel();
    }

    void Setup()
    {
        // Grid finds size
        roomH = Mathf.RoundToInt(roomSizeWorldUnits.x / worldUnitsInOneGridCell);
        roomW = Mathf.RoundToInt(roomSizeWorldUnits.y / worldUnitsInOneGridCell);
        //Grid creation
        grid = new gridSpace[roomW,roomH];
        //Default grid set
        for (int x = 0; x < roomW-1; x++)
        {
            for (int y = 0; y < roomH-1; y++)
            {
                //Every cell made empty
                grid[x, y] = gridSpace.empty;
            }
        }
        //First walk set
        mappers = new List<map>();
        //walk created 
        map newmap = new map();
        newmap.direction = RandomDirection();
        //Grid center found
        Vector2 spawnPosition = new Vector2(Mathf.RoundToInt(roomW / 2.0f), 
                                             Mathf.RoundToInt(roomH / 2.0f));
        newmap.position = spawnPosition;
        //Walk added to list
        mappers.Add(newmap);
    }

    void CreateFloor()
    {
        int loop = 0;
        do
        {
            //Floor creation 
            foreach (map mymap in mappers)
            {
                grid[(int)mymap.position.x,(int)mymap.position.y] = gridSpace.floor;
            }

            //Destroy walk : chance
            int checksNumber = mappers.Count;
            for (int j = 0; j < checksNumber; j++)
            {
                //if its not the only one. and at a low chance
                if (Random.value < chWalkDestroy && mappers.Count > 1)
                {
                    mappers.RemoveAt(j);
                    break; // Destroy one per loop
                }
            }

            //Pick new direction
            for (int j = 0; j < mappers.Count; j++)
            {
                if (Random.value < chwalkChangeDirection)
                {
                    map walkThis = mappers[j];
                    walkThis.direction = RandomDirection();
                    mappers[j] = walkThis;
                }
            }

            //Spawn new walk chance
            checksNumber = mappers.Count;
            for (int j = 0; j < checksNumber; j++)
            {
                if (Random.value < chWalkSpawn && mappers.Count < mappersMax)
                {
                    //walk creation
                    map newWalk = new map();
                    newWalk.direction = RandomDirection();
                    newWalk.position = mappers[j].position;
                    mappers.Add(newWalk);
                }
            }

            //walk movement 
            for (int j = 0; j < mappers.Count; j++)
            {
                map walkThis = mappers[j];
                walkThis.position += walkThis.direction;
                mappers[j] = walkThis;
            }

            //Boarder avoided
            for (int j =0; j < mappers.Count; j++)
            {
                map Theywalk = mappers[j];
                //Adds a clamp/limit on the space they have
                Theywalk.position.x = Mathf.Clamp(Theywalk.position.x, 1, roomW-2);
                Theywalk.position.y = Mathf.Clamp(Theywalk.position.y, 1, roomH-2);
                mappers[j] = Theywalk;
            }

            //ending the loop
            if ((float)FloorNumber() / (float)grid.Length > fillPercent)
            {
                break;
            }
            loop++; 
        } while (loop < 10000);
    }

    void CreateWalls()
    {
        //Loop through every grid space
        for (int x = 0; x < roomW - 1; x++)
        {
            for (int y = 0; y < roomH - 1; y++)
            {
                //Checks to see if floor is there and works around it
                if (grid[x,y] == gridSpace.floor)
                {
                    //if space around = empty place wall
                    if (grid[x,y + 1] == gridSpace.empty)
                    {
                        grid[x, y + 1] = gridSpace.wall;
                    }
                    if (grid[x, y - 1] == gridSpace.empty)
                    {
                        grid[x, y - 1] = gridSpace.wall;
                    }
                    if (grid[x + 1, y] == gridSpace.empty)
                    {
                        grid[x + 1, y] = gridSpace.wall;
                    }
                    if (grid[x - 1, y] == gridSpace.empty)
                    {
                        grid[x - 1, y] = gridSpace.wall;
                    }
                }
            }
        }
    }

    void EnemySpawnPos()
    { 

    }

    void PlayerSpawn()
    {
        Instantiate(Player);
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
                        Spawn(x,y,Floor);
                        break;
                    case gridSpace.wall:
                        Spawn(x,y,Wall);
                        break;
                    case gridSpace.player:
                        Spawn(x, y, Player);
                        break;
                    case gridSpace.enemies:
                        Spawn(x, y, Enemy);
                        break;
                }
            }
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

    Vector2 RandomDirection()
    {
        //Random int Picked form 0-3
        int Choice = Mathf.FloorToInt(Random.value * 3.99f);
        //chose a direction
        switch (Choice)
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

}
