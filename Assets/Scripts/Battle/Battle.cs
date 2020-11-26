using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public Player PlayerPrefab;

    private Player _player;
    private Map _map;   

    private void Start()
    {
        _map = FindObjectOfType<Map>();
        _player = Instantiate(PlayerPrefab);

        _map.CreateMap();
        _player.Create(_map);
    }

    private void Update()
    {
        _player.Move();
    }
}
