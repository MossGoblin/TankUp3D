using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaster : MonoBehaviour
{
    // master control
    public bool tiledTerrain = true;
    // dimentions
    [SerializeField] public int depth;
    [SerializeField] public int width;

    // refs
    [SerializeField] GameMaster master;
    [SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject largeTilePrefab;
    [SerializeField] GameObject tileHolder;

    // grid
    public int[,] grid;

    // Start is called before the first frame update
    void Start()
    {
        // BuildTileMap();
        BuildSingletonTileMap();

        // if (tiledTerrain)
        // {
        //     BuildTileMap();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildTileMap()
    {
        grid = new int[width, depth];
        for (int countW = 0; countW < width; countW++)
        {
            for (int countD = 0; countD < depth; countD++)
            {
                Vector3 newTilePosition = new Vector3((float)countW, -0f, (float)countD);
                GameObject newTile = Instantiate(tilePrefab, newTilePosition, Quaternion.identity, tileHolder.transform);
                newTile.layer = tileHolder.gameObject.layer;

            }
        }
    }
    private void BuildSingletonTileMap()
    {
                Vector3 newTilePosition = new Vector3((float)width/2, -0f, (float)depth/2);
                GameObject newTile = Instantiate(largeTilePrefab, newTilePosition, Quaternion.identity, tileHolder.transform);
                // Vector3 newScale = new Vector3(150f, 0f, 150f);
                // newTile.transform.localScale = newScale;
                newTile.layer = tileHolder.gameObject.layer;


    }
}
