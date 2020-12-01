using NikolayKorobov;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Castle : Build
{
    [SerializeField] private int _territory = 1;

    public int Territory => _territory;


    public override List<SelectMap> Select()
    {
        var tiles = _map.Graph.Neighbor(Tile, Territory).VerticesToNames;
        var selects = new List<SelectMap>();

        tiles
            .Where(t => t != null)
            .ToList()
            .ForEach(t => selects.Add(t.Select(_map.PrefabSelect.ColorSelectActiveActor)));

        return selects;
    }
}
