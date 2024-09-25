using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeCell MazeCellPrefab;

    [SerializeField]
    private int mazeWidth;

    [SerializeField]
    private int mazeDepth;

    private MazeCell[,] mazeGrid;

    private FirstDepthSearchGen generator;
    private bool Play = false;


    // Start is called before the first frame update
    void Start()
    {
        mazeGrid = new MazeCell[mazeWidth, mazeDepth];
        for(int i= 0; i< mazeDepth; i++)
        {
            for(int j = 0; j < mazeWidth; j++)
            {
                mazeGrid[j, i] = Instantiate(MazeCellPrefab, new Vector3(i, 0, j), Quaternion.identity);
            }
        }
        generator = new FirstDepthSearchGen(mazeGrid);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Play = !Play;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < mazeDepth; i++)
            {
                for (int j = 0; j < mazeWidth; j++)
                {
                    Destroy(mazeGrid[j, i].gameObject);
                    mazeGrid[j, i] = Instantiate(MazeCellPrefab, new Vector3(i, 0, j), Quaternion.identity);
                }
            }
            generator = new FirstDepthSearchGen(mazeGrid);
        }
        if (Play)
        {
            while (true)
            {
                if (generator.GenStep()) break;
            }
            
        }
        

    }

}
