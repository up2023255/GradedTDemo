using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapVisualiser : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTileMap, wallTileMap;
    [SerializeField]
    private TileBase floorTile, wallTop;

    public void paintFloorTile(IEnumerable<Vector2Int> floorPos)
    {
        paintTiles(floorPos, floorTileMap, floorTile);
    }

    internal void PaintSingleBasicWall(Vector2Int position)
    {
        paintSingleTiles(wallTileMap, wallTop, position);       
    }

    private void paintTiles(IEnumerable<Vector2Int> position, Tilemap tileMap, TileBase tile)
    {
        foreach (var positions in position)
        {
            paintSingleTiles(tileMap, tile, positions);
        }
    }

    private void paintSingleTiles(Tilemap tileMap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tileMap.WorldToCell((Vector3Int)position);
        tileMap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        floorTileMap.ClearAllTiles();
        wallTileMap.ClearAllTiles();
    }
}
