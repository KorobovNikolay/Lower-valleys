using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bot", menuName = "Data/Player/Bot")]
public class Bot : Player
{
    private Battle _battle;

    public override void Create(Map map)
    {
        base.Create(map);

        _battle = FindObjectOfType<Battle>();
    }

    public override void Move()
    {
        Debug.Log("Bot сделал ход");
        _battle.NextPlayer();
    }
}
