using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "Data/Map")]
public class DataMap : ScriptableObject
{

    

    [Header("Размер карты")]
    [Range(7, 30)]
    public int Width = 5;
    [Range(7, 30)]
    public int Height = 5;
    [Range(1, 5)]
    public float Scale = 1f;

    [Header("Префабы тайлов")]
    [Space]
    public Tile PrefabEarth;
    public Tile PrefabShores;
    public Tile PrefabWater;

    public float Size => Width * Height;
    public float TileWidth => PrefabEarth.GetComponent<MeshFilter>().sharedMesh.bounds.size.x;
    public float TileHeight => PrefabEarth.GetComponent<MeshFilter>().sharedMesh.bounds.size.z;
    public float TileOffsetPosition => TileHeight * 0.75f;
}
