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
    public List<Build> Builds { get; private set; }
    public List<Champion> Champions { get; private set; }

    protected CameraMove _cameraMove;
    protected Camera _camera;
    protected Map _map;

    public virtual void Create(Map map)
    {
        _cameraMove = FindObjectOfType<CameraMove>();
        _camera = FindObjectOfType<Camera>();
        _map = map;

        Builds = new List<Build>();
        Champions = new List<Champion>();

        var tilesField = _map.GetTiles<Field>();
        var tileCreateObject = tilesField[Random.Range(0, tilesField.Count)];
            
        AddBuild<Castle>(tileCreateObject);
        AddChampion<ChampionLevel1>(tileCreateObject);
    }

    public virtual void Refresh()
    {
        Champions.ForEach(ch => ch.Refresh());
        Builds.ForEach(b => b.Refresh());
    }

    public abstract void Move();

    public void AddChampion<T>(Tile tile)
    {
        var champion = Instantiate(_champions.Find(ch => ch is T));
            champion.Create(this, tile);

        Champions.Add(champion);
    }

    public void AddBuild<T>(Tile tile)
    {
        var build = Instantiate(_builds.Find(b => b is T));
            build.Create(this, tile);

        Builds.Add(build);
    }

    
}
