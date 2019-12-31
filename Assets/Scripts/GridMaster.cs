using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaster : MonoBehaviour
{
    //dimentions
    [SerializeField] public int depth;
    [SerializeField] public int width;

    // refs
    [SerializeField] GameMaster master;
    [SerializeField] GameObject simpleTilePrefab;
    [SerializeField] GameObject tileHolder;

    // grid
    public int[,] grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new int[width, depth];
        for (int countW = 0; countW < width; countW++)
        {
            for (int countD = 0; countD < depth; countD++)
            {
                Vector3 newTilePosition = new Vector3((float)countW, 0f, (float)countD);
                Instantiate(simpleTilePrefab, newTilePosition, Quaternion.identity, tileHolder.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
