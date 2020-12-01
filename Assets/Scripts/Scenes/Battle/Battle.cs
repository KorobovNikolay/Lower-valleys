using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [SerializeField] private int _indexPlayer = 0;
    [SerializeField] private List<Player> _playersPrefab = null;
    
    private List<Player> _players;
    private Player _currentPlayer;
    private Map _map;   

    public void NextPlayer()
    {
        var index = _players.IndexOf(_currentPlayer) + 1;
        if (index > _players.Count - 1) index = 0;

        _currentPlayer = _players[index];
    }

    private void Start()
    {
        _map = FindObjectOfType<Map>();
        _players = new List<Player>();
        _playersPrefab.ForEach(p => _players.Add(Instantiate(p)));

        _map.CreateMap();
        _players.ForEach(p => p.Create(_map));
        _currentPlayer = _players[_indexPlayer];
    }

    private void Update()
    {
        _currentPlayer.Move();
    }
}
