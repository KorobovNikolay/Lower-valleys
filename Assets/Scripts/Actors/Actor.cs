using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    [SerializeField] private string _name = "Name actor";

    public string Name => _name;
    public Player Player { get; set; }
    public Tile Tile { get; set; }
    
    protected Map _map;

    public virtual void Create(Player player, Tile tile)
    {
        Player = player;
        Tile = tile;
        _map = FindObjectOfType<Map>();

        transform.position = Tile.transform.position;
        transform.SetParent(Tile.transform);
    }

    public void ChangeTile(Tile tile)
    {
        Tile = tile;
        transform.position = Tile.transform.position;
        transform.SetParent(Tile.transform);
    }

    public abstract void Refresh();

    public abstract void Move(Tile tile);

    public abstract List<SelectMap> Select();

    
}
