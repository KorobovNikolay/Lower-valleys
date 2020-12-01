using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour
{
    [SerializeField] private Color _colorSelectTile = default;
    [SerializeField] private Color _colorSelectObject = default;
    [SerializeField] private Color _colorSelectAtack = default;

    public Color ColorSelectTile => _colorSelectTile;
    public Color ColorSelectObject => _colorSelectObject;
    public Color ColorSelectAtack => _colorSelectAtack;
}
