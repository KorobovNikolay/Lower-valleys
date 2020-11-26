using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise
{
    private int _width;
    private int _height;
    private float _offsetX;
    private float _offsetY;
    private float _scale;

    public PerlinNoise(int width, int height, float xOffset, float yOffset, float scale)
    {
        _width = width;
        _height = height;
        _offsetX = xOffset;
        _offsetY = yOffset;
        _scale = scale;
    }

    public Texture2D CreateTexture()
    {
        var texture = new Texture2D(_width, _height);

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var sample = GetSample(x, y);
                var color = new Color(sample, sample, sample);

                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        return texture;
    }

    public float GetSample(int x, int y)
    {
        var xCoordinate = (float)x / _width * _scale + _offsetX;
        var yCoordinate = (float)y / _height * _scale + _offsetY;

        var sample = Mathf.PerlinNoise(xCoordinate, yCoordinate);

        return sample;
    }
}
