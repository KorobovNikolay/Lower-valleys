using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champion : MonoBehaviour
{
    [SerializeField] private string _name = "Name champion";

    public string Name => _name;
    public Tile Tile { get; set; }
}
