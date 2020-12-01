using NikolayKorobov;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GraphMap
{
    private Graph<Tile> _graph;

    public GraphMap(List<Tile> tiles)
    {
        _graph = new Graph<Tile>();

        // Создание вершин
        tiles.ForEach(tile => _graph.AddVertex(tile));

        
        // Создание ребер
        tiles
            .ForEach(tile => tile.Neighbor()
            .Where(tileNeighbor => tileNeighbor != null)
            .ToList()
            .ForEach(tileConnected => _graph.AddUndirectedEdge(tile, tileConnected, 1)));
    }

    public List<Tile> NeighborByWeightTile(Tile tile, int depth)
    {
        return _graph.Neighbor(tile, depth).VerticesToNames();
    }
}
