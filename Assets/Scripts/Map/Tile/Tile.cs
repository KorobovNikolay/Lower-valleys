using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector3 Coordinate { get; set; }

    protected Map _map;
    protected MeshFilter _meshFilter;

    public void Init(Map map, Vector3 coordinate)
    {
        _map = map;
        _meshFilter = GetComponent<MeshFilter>();

        var horizontal = _map.Data.TileWidth;
        var vertical = _map.Data.TileOffsetPosition;
        var position =
            new Vector3
            (
            x: horizontal * (coordinate.x + coordinate.y / 2f),
            y: transform.position.y,
            z: vertical * coordinate.y
            );

        Coordinate = coordinate;
        transform.position = position;
        transform.parent = _map.transform;
        name = Coordinate.ToString();
    }

    public SelectMap Select(Color color)
    {
        var offsetUp = 0.05f;
        var position = new Vector3(transform.position.x, transform.position.y + offsetUp, transform.position.z);
        var transformSelect = Instantiate(_map.PrefabSelect);
        var materialSelect = transformSelect.GetComponent<Renderer>().material;

        materialSelect.SetColor("_ColorSelect", color);
        transformSelect.transform.position = position;

        return transformSelect;
    }

    public List<Tile> Neighbor()
    {
        var tiles = new List<Tile>();
            tiles.Add(NeighborRight());
            tiles.Add(NeighborUpRight());
            tiles.Add(NeighborUpLeft());
            tiles.Add(NeighborLeft());
            tiles.Add(NeighborDownLeft());
            tiles.Add(NeighborDownRight());

        return tiles;
    }

    public Tile Neighbor(Vector3 coordinate)
    {
        return _map.GetTile(
            new Vector3(
                Coordinate.x + coordinate.x, 
                Coordinate.y + coordinate.y, 
                Coordinate.z + coordinate.z));
    }

    public Tile NeighborRight()
    {
        return Neighbor(new Vector3(1, 0, -1));
    }

    public Tile NeighborLeft()
    {
        return Neighbor(new Vector3(-1, 0, +1));
    }

    public Tile NeighborDownLeft()
    {
        return Neighbor(new Vector3(0, -1, 1));
    }

    public Tile NeighborUpLeft()
    {
        return Neighbor(new Vector3(-1, +1, 0));
    }

    public Tile NeighborUpRight()
    {
        return Neighbor(new Vector3(0, +1, -1));
    }

    public Tile NeighborDownRight()
    {
        return Neighbor(new Vector3(+1, -1, 0));
    }

    
}
