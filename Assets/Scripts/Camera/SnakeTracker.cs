using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTracker : MonoBehaviour
{
    [SerializeField] private Transform _snake;
    [SerializeField] private float _distance;
    private void FixedUpdate()
    {

        transform.position = GetMove();
    }

    private Vector3 GetMove()
    {
        var snakePosition = new Vector3(transform.position.x, transform.position.y, _snake.position.z + _distance);
        return snakePosition;
    }
}
