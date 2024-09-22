using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject EastWall;

    [SerializeField]
    private GameObject WestWall;

    [SerializeField]
    private GameObject NorthWall;

    [SerializeField]
    private GameObject SouthWall;

    [SerializeField]
    private GameObject UnvisitedCell;

    public bool Isvisited { get; private set;}

    public void Visit()
    {
        Isvisited = true;
        UnvisitedCell.SetActive(false);
    }

    public void ClearEastWall()
    {
        EastWall.SetActive(false);
    }

    public void ClearWestWall()
    {
        WestWall.SetActive(false);
    }

    public void ClearNorthWall()
    {
        NorthWall.SetActive(false);
    }

    public void ClearSouthWall()
    {
        SouthWall.SetActive(false);
    }
}
