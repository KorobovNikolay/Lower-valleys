using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour
{
    [SerializeField] private Color _colorSelectTile = default;
    [SerializeField] private Color _colorSelectActiveActor = default;
    [SerializeField] private Color _colorSelectNotActiveActor = default;
    [SerializeField] private Color _colorSelectAtack = default;

    public Color ColorSelectTile => _colorSelectTile;
    public Color ColorSelectActiveActor => _colorSelectActiveActor;
    public Color ColorSelectNotActiveActor => _colorSelectNotActiveActor;
    public Color ColorSelectAtack => _colorSelectAtack;
}
