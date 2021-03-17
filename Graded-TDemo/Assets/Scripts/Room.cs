using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room 
{
    public Vector2 gridpos;
    public int type;
    public bool doorT, doorB, doorL, doorR;

    public Room(Vector2 _gridpos, int _type)
    {
        gridpos = _gridpos;
        type = _type;
    }
}
