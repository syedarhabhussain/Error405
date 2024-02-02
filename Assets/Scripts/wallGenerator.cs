using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class wallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TileMapViz tilemapVisualizer)
    {
        var basicWallPos = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionList);
        var cornerWallPos = FindWallsInDirections(floorPositions, Direction2D.diagonalDirectionList);

        CreateBasicWalls(tilemapVisualizer, basicWallPos, floorPositions);
        CreateCornerWalls(tilemapVisualizer, cornerWallPos, floorPositions);
    }

    private static void CreateCornerWalls(TileMapViz tilemapVisualizer, HashSet<Vector2Int> cornerWallPos, HashSet<Vector2Int> floorPositions)
    {
        foreach (var position in cornerWallPos)
        {
            string neighborsBinaryType = "";

            foreach (var direction in Direction2D.eightDirectionList)
            {
                var neighborPos = position + direction;
                if (floorPositions.Contains(neighborPos))
                {
                    neighborsBinaryType += "1";
                }
                else
                {
                    neighborsBinaryType += "0";
                }
            }
            tilemapVisualizer.PaintSingleCornerWall(position, neighborsBinaryType);
        }
    }

    private static void CreateBasicWalls(TileMapViz tilemapVisualizer, HashSet<Vector2Int> basicWallPos, HashSet<Vector2Int> floorPositions)
    {
        foreach (var position in basicWallPos)
        {
            string neighborsBinaryType = "";
            foreach(var direction in Direction2D.cardinalDirectionList)
            {
                var neighborPos = position + direction;
                if (floorPositions.Contains(neighborPos))
                {
                    neighborsBinaryType += "1";
                }
                else
                {
                    neighborsBinaryType += "0";
                }
            }
            tilemapVisualizer.paintSingleBasicWall(position, neighborsBinaryType);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions)
        {
            foreach (var direction in directionList)
            {
                var neighbourPosition  = position + direction;
                if(floorPositions.Contains(neighbourPosition) == false)
                        wallPositions.Add(neighbourPosition);
            }
        }
        return wallPositions;
    }
}
