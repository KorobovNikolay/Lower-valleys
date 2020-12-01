﻿using NikolayKorobov;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour
{
    [Header("Данные карты")]
    [SerializeField] private DataMap _data = null;

    [Header("Выделения на карте")]
    [Space]
    [SerializeField] private SelectMap _prefabSelect = null;

    public DataMap Data => _data;
    public SelectMap PrefabSelect => _prefabSelect;
    public Graph<Tile> Graph { get; private set; } 
    public List<Tile> Tiles { get; private set; }

    private PerlinNoise _noise;

    public Tile GetTile(Vector3 coordinate)
    {
        return Tiles.Find(t => t.Coordinate.Equals(coordinate));
    }

    public List<T> GetTiles<T>()
    {
        return Tiles
            .Where(t => t is T)
            .Select(t => (T)(t as object))
            .ToList();
    }

    public void CreateMap()
    {
        Tiles = new List<Tile>();

        _noise = new PerlinNoise(
            Data.Width,
            Data.Height,
            UnityEngine.Random.Range(0f, 99999f),
            UnityEngine.Random.Range(0f, 99999f),
            Data.Scale);

        // Создания тайлов по шуму
        for (int column = 0; column < Data.Width; column++)
        {
            for (int row = 0; row < Data.Height; row++)
            {
                var sample = _noise.GetSample(column, row);

                if (sample < 0.35f)
                    Tiles.Add(CreateTile(Data.PrefabWater, CreateCoordinate(column, row)));
                if (sample >= 0.35f && sample < 0.5f)
                    Tiles.Add(CreateTile(Data.PrefabShores, CreateCoordinate(column, row)));
                if (sample >= 0.5f)
                    Tiles.Add(CreateTile(Data.PrefabEarth, CreateCoordinate(column, row)));
            }
        }

        CreateGraph();
    }

    private void CreateGraph()
    {
        Graph = new Graph<Tile>();

        // Создание вершин
        Tiles.ForEach(tile => Graph.AddVertex(tile));


        // Создание ребер
        Tiles
            .ForEach(tile => tile.Neighbor()
            .Where(tileNeighbor => tileNeighbor != null)
            .ToList()
            .ForEach(tileConnected => Graph.AddUndirectedEdge(tile, tileConnected, 1)));
    }

    private Vector3 CreateCoordinate(int column, int row)
    {
        // Смешение координат в четное по ячекам;
        int x = column - (row + (row & 1)) / 2;
        int y = row;
        int z = -(x + y);

        return new Vector3(x, y, z);
    }

    private Tile CreateTile(Tile prefab, Vector3 coordinate)
    {

        var tile = Instantiate(prefab);
        tile.Init(this, coordinate);

        return tile;
    }




}
