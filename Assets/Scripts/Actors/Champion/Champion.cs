using NikolayKorobov;
using System.Collections.Generic;
using UnityEngine;

public class Champion : Actor
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private int _weightMove = 1;
    [SerializeField] private int _weightAttack = 1;
    [SerializeField] private bool _isMoveOnWater = false;

    public int WeightMove { get; private set; }
    public int WeightAttack { get; private set; }

    private List<Tile> _tilesMove = new List<Tile>();
    private List<Tile> _tilesAtack = new List<Tile>();
    private List<Tile> _pointTileMove = new List<Tile>();
    private int _tileIndex = 0;
    private bool _isMoving = false;

    public override void Create(Player player, Tile tile)
    {
        base.Create(player, tile);

        WeightMove = _weightMove;
        WeightAttack = _weightAttack;
    }

    public override void Refresh()
    {
        WeightMove = _weightMove;
    }

    public override void Move(Tile targetTile)
    {
        if (_map.Graph.Section(_tilesMove).VerticesToNames.Contains(targetTile))
        {
            _tilesMove.Add(Tile);

            if (_isMoving is false)
            {
                _pointTileMove = _map.Graph.Section(_tilesMove).Dijkstra(Tile, targetTile).VerticesToNames;
                _isMoving = true;
                _tileIndex = 0;
               
                WeightMove = 0;
            }
        }
    }

    public override List<SelectMap> Select()
    {
        var listSelected = new List<SelectMap>();

        _tilesMove.Clear();
        _tilesAtack.Clear();

        // Тайлы по которым можно перемешатся
        foreach (var t in _map.Graph.Neighbor(Tile, WeightMove).VerticesToNames)
        {
            if (_isMoveOnWater)
                _tilesMove.Add(t);

            else
            {
                if (!(t is Water))
                    _tilesMove.Add(t);
            }
        }

        // Тайлы которые можно атакова
        foreach (var t in _map.Graph.Neighbor(Tile, WeightAttack).VerticesToNames)
        {
            var champion = t.GetComponentInChildren<Champion>();
            if (champion != null)
                if (!champion.Player.Equals(Player))
                {
                    _tilesAtack.Add(t);
                    _tilesMove.Remove(t);
                }
        }

        // Выделение тайлов
        _tilesMove.ForEach(t => listSelected.Add(t.Select(_map.PrefabSelect.ColorSelectActiveActor)));
        _tilesAtack.ForEach(t => listSelected.Add(t.Select(_map.PrefabSelect.ColorSelectAtack)));

 
        // Если у чемпиона закончились ходы
        if (WeightMove.Equals(0))
            listSelected.Add(Tile.Select(_map.PrefabSelect.ColorSelectNotActiveActor));

        return listSelected;
    }

    private void Update()
    {
        if (_isMoving)
        {
            // Если задан путь
            if (_pointTileMove.Count != 0)
            {
                // Если достигнута очередная точка
                if (Vector3.Distance(_pointTileMove[_tileIndex].transform.position, transform.position) <= 0)
                {
                    _tileIndex++;
                }

                //Прекратить движение если конец
                if (_tileIndex >= _pointTileMove.Count)
                {
                    ChangeTile(_pointTileMove[_tileIndex - 1]);
                    _tileIndex = 0;
                    _isMoving = false;
                }

                transform.position = Vector3.MoveTowards(transform.position, _pointTileMove[_tileIndex].transform.position, _speed * Time.deltaTime);
            }
        }
    }

    
}
