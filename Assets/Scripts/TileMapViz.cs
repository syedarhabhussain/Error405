using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapViz : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap;
    [SerializeField]
    private TileBase floorTile; //change to array for random tile
    [SerializeField]
    private TileBase wallTop, wallSideRight, wallSideLeft, wallBottom, wallFull,
        wallInnerCornerDownLeft, wallInnerCornerDownRight, 
        WallDiagonalCornerDownRight, WallDiagonalCornerDownLeft,
        wallDiagonalCornerUpRight, wallDiagonalCornerUpLeft;
    [SerializeField]
    private Tilemap wallTilemap;
   
    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTilemap, floorTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions) 
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
           floorTilemap.ClearAllTiles();
           wallTilemap.ClearAllTiles();
    }

    internal void paintSingleBasicWall(Vector2Int position, string binaryType)
    {
        int typeAsint = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;

        if(WallByteTypes.wallTop.Contains(typeAsint))
        {
            tile = wallTop;
        }
        else if (WallByteTypes.wallSideRight.Contains(typeAsint)){
            tile = wallSideRight;
        }
        else if (WallByteTypes.wallSideLeft.Contains(typeAsint))
        {
            tile = wallSideLeft;
        }
        
        else if (WallByteTypes.wallBottm.Contains(typeAsint))
        {
            tile = wallBottom;
        }
        
        else if (WallByteTypes.wallFull.Contains(typeAsint))
        {
            tile = wallFull;
        }

        if(tile != null)
        {
            PaintSingleTile(wallTilemap, tile, position);
        }

        
    }

    internal void PaintSingleCornerWall(Vector2Int position, string binaryType)
    {
       int typeAsInt = Convert.ToInt32(binaryType, 2);
       TileBase tile = null;

        if (WallByteTypes.wallInnerCornerDownLeft.Contains(typeAsInt))
        {
            tile = wallInnerCornerDownLeft;
        }
        else if (WallByteTypes.wallInnerCornerDownRight.Contains(typeAsInt))
        {
            tile = wallInnerCornerDownRight;
        }
        else if (WallByteTypes.wallDiagonalCornerDownLeft.Contains(typeAsInt))
        {
            tile = WallDiagonalCornerDownLeft;
        }
        else if (WallByteTypes.wallDiagonalCornerDownRight.Contains(typeAsInt))
        {
            tile = WallDiagonalCornerDownRight;
        }
        else if (WallByteTypes.wallDiagonalCornerUpRight.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerUpRight;
        }
        else if (WallByteTypes.wallDiagonalCornerUpLeft.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerUpLeft;
        }
        else if (WallByteTypes.wallFullEightDirections.Contains(typeAsInt))
        {
            tile = wallFull;
        }
        else if (WallByteTypes.wallBottmEightDirections.Contains(typeAsInt))
        {
            tile = wallBottom;
        }

        if (tile != null)
        {
            PaintSingleTile(wallTilemap, tile, position);
        }

    }
}
