using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;


public class GridManager : MonoBehaviour 
{
    private int width, height;
    private float cellSize;
    private int[,] gridArray;
    //public Tile[,] tileArray { get; set; }
    int i=-2;
    

    [SerializeField] private Tile pfTile;

   [SerializeField] private Transform camObj;

    private Dictionary<int, Tile> tileList;
    private Dictionary<Vector2, Tile> tileDict;

    private void Awake()
    {
        GridArray(18, 10, 5);
    }

    private void GridArray(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];
        //tileArray = new Tile[width, height];
        tileDict = new Dictionary<Vector2, Tile>();
        tileList = new Dictionary<int, Tile>();
        

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            i++;
            for(int y = 0; y< gridArray.GetLength(1); y++)
            {
                i++;
                Tile spawnedTile = Instantiate(pfTile, transform.position + new Vector3(x-0.5f, y+0.5f), Quaternion.identity, transform);
                spawnedTile.name = $"Tile{i} {x} {y}";
                bool isOffset = (x % 2 == 0 &&  y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                pfTile.Init(isOffset);

                tileList[i] = spawnedTile;
                tileDict[new Vector2(x, y)] = spawnedTile;

            }
        }

       // camObj.transform.position = new Vector3((float)width/2 -0.5f, (float)height/2 -0.5f, -10);
    }

    public Tile GetTile(int count)
    {
        if (tileList.TryGetValue(count, out Tile tile)) return tile;
        return null;
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x,y) * cellSize;
    }

    public Tile GetTileAtPosition(Vector2 position)
    {
        if(tileDict.TryGetValue(position, out  Tile tile)) return tile;
        return null;
    }
}
