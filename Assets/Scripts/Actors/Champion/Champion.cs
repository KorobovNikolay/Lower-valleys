using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Champion : Actor
{
    [SerializeField] private int _weightMove = 1;

    public int WeightMove => _weightMove;

    public override List<SelectMap> Select()
    {
        var tiles = _map.Graph.NeighborByWeightTile(Tile, WeightMove);
        var selects = new List<SelectMap>();

        tiles
            .Where(t => t != null)
            .ToList()
            .ForEach(t => selects.Add(t.Select(_map.PrefabSelect.ColorSelectObject)));

        return selects;
    }
}
