using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public abstract class Player : ScriptableObject
{
    [SerializeField] private string _name = "Name player";

    [Header("Здания")]
    [Space]
    [SerializeField] private List<Build> _builds = null;

    [Header("Чемпионы")]
    [Space]
    [SerializeField] private List<Champion> _champions = null;

    public string Name => _name;

    protected CameraMove _cameraMove;
    protected Camera _camera;
    protected Map _map;

    public virtual void Create(Map map)
    {
        _cameraMove = FindObjectOfType<CameraMove>();
        _camera = FindObjectOfType<Camera>();
        _map = map;

        var tilesField = _map.GetTiles<Field>();
        var tileCreateObject = tilesField[Random.Range(0, tilesField.Count)];
            
        AddObject<Castle>(tileCreateObject);
        AddChampion<ChampionLevel1>(tileCreateObject);

        _cameraMove.LookAtTile(tileCreateObject);
    }

    public abstract bool Move();

    public void AddChampion<T>(Tile tile)
    {
        var champion = Instantiate(_champions.Find(ch => ch is T));
            champion.transform.position = new Vector3(tile.transform.position.x, champion.transform.position.y, tile.transform.position.z + champion.transform.position.z);
            champion.Tile = tile;
    }

    public void AddObject<T>(Tile tile)
    {
        var build = Instantiate(_builds.Find(b => b is T));
            build.Tile = tile;
            build.transform.position = tile.transform.position;
    }

    
}
