using NikolayKorobov;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphMap
{
    private List<Tile> _tiles;
    private Graph<Tile> _graph;

    public GraphMap(List<Tile> tiles)
    {
        _tiles = tiles;
        _graph = new Graph<Tile>();

        // Создание вершин
        foreach (var tile in _tiles)
            _graph.AddVertex(tile);

        // Создание ребер
        foreach (var tile in _tiles)
        {
            foreach (var coordinate in tile.Neighbor())
            {
                var connectedTile = _tiles.Find(t => t.Coordinate.Equals(coordinate));

                if (connectedTile != null)
                    _graph.AddUndirectedEdge(tile, connectedTile, 1);

            }
        }
    }

    public List<Tile> NeighborTile(Tile tile)
    {
        return _graph.Neighbor(tile, 1).VerticesToNames();
    }
}
