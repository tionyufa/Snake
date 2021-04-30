using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakeColor : MonoBehaviour
{
    [SerializeField] private List <MeshRenderer> _colorSnake;

    public void ColorSnake()
    {
        var color = ColorController.Singleton.GetGoodMaterial();
        foreach (var colorSnake in _colorSnake)
        {
            colorSnake.material = color;
        }
    }
}
