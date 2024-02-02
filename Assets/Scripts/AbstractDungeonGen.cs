using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDungeonGen : MonoBehaviour
{
    [SerializeField]
    protected TileMapViz tilemapVisualizer = null;

    [SerializeField]
    protected Vector2Int startPosition = new Vector2Int(0, 0);

    public void GenerateDungeon()
    {
        tilemapVisualizer.Clear();
        RunProceduralGeneration();

    }

    protected abstract void RunProceduralGeneration();
}
