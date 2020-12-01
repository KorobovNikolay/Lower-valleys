using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] private string _name = "Name actor";

    public string Name => _name;

    protected Tile _tile;
    protected Map _map;

    public virtual List<SelectMap> Select()
    {
        return new List<SelectMap>()
        {
            _tile.Select(_map.PrefabSelect.ColorSelectObject)
        };
    }

    private void Start()
    {
        _tile = GetComponentInParent<Tile>();
        _map = FindObjectOfType<Map>();
    }

    
}
