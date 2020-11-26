using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    [SerializeField] string _name = "Name build";

    public string Name => _name;
    public Tile Tile { get; set; }
}
