using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] private string _name = "Name actor";

    public string Name => _name;
    public Player Player { get; set; }
    public Tile Tile { get; private set; }
    
    protected Map _map;

    public virtual void Create(Player player, Tile tile)
    {
        Player = player;
        Tile = tile;
        _map = FindObjectOfType<Map>();

        transform.position = Tile.transform.position;
        transform.SetParent(Tile.transform);
    }

    public virtual List<SelectMap> Select()
    {
        return new List<SelectMap>()
        {
            Tile.Select(_map.PrefabSelect.ColorSelectObject)
        };
    }
}
