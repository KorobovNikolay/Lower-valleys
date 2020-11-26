using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fps : MonoBehaviour
{
    private Text _textFps;

    private void Start()
    {
        _textFps = GetComponent<Text>();
    }

    private void Update()
    {
        var fps = 1.0f / Time.deltaTime;

        _textFps.text = $"Fps: {(int)fps}";

    }
}
