using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Tile
{
    public GameObject FaceUpLefth;
    public GameObject FaceUpRight;
    public GameObject FaceDownLefth;
    public GameObject FaceDownRight;

    private void Start()
    {
        if (-Coordinate.x == Coordinate.z)
        {
            FaceDownLefth.SetActive(true);
            FaceDownRight.SetActive(true);
        }


        if (Coordinate.y == _map.Data.Height - 1)
        {
            FaceUpRight.SetActive(true);
            FaceUpLefth.SetActive(true);
        }



        if ((Coordinate.x + 1) == Coordinate.z)
        {
            FaceUpLefth.SetActive(true);
            FaceDownLefth.SetActive(true);
        }

        if (NeighborRight() == null && Coordinate.y % 2 == 0)
        {
            FaceUpRight.SetActive(true);
            FaceDownRight.SetActive(true);
        }

    }
}
