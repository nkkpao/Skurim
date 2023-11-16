using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;



public class GridManager : MonoBehaviour 
{
    private int width, height;
    private float cellSize;
    private int[,] gridArray;
    //public Tile[,] tileArray { get; set; }

    

    [SerializeField] private Tile pfTile;

   [SerializeField] private Transform camObj;

    private Dictionary<Vector2, Tile> tileArray;

    private void Awake()
    {
        GridArray(30, 15, 5);
    }

    private void GridArray(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];
        //tileArray = new Tile[width, height];
        tileArray = new Dictionary<Vector2, Tile>();


        for (int x = 0; x<gridArray.GetLength(0); x++){        
            for(int y = 0; y<gridArray.GetLength(1); y++)
            {
                Tile spawnedTile = Instantiate(pfTile, new Vector3(x-width/2,y-height/2), Quaternion.identity, transform);
                spawnedTile.name = $"Tile {x} {y}";
                bool isOffset = (x % 2 == 0 &&  y % 2 != 0) || (x % 2 != 0 && y % 2 != 0);
                pfTile.Init(isOffset);

                tileArray[new Vector2(x, y)] = spawnedTile;

            }
        }

       // camObj.transform.position = new Vector3((float)width/2 -0.5f, (float)height/2 -0.5f, -10);
    }



    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x,y) * cellSize;
    }

    public Tile GetTileAtPosition(Vector2 position)
    {
        if(tileArray.TryGetValue(position, out  Tile tile)) return tile;
        return null;
    }
}
