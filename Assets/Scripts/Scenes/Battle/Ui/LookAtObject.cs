using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtObject : MonoBehaviour
{
    public Button LookAtChampion;
    public Button LookAtCastle;

    private Battle _battle;

    private void Start()
    {
        _battle = FindObjectOfType<Battle>();

        LookAtChampion.onClick.AddListener(() =>
        {
            _battle.NextPlayer();
        });
    }
}
