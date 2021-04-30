using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead _head;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _tailSpringles;
    [SerializeField] private List<GameObject> _tails;
    private float _angel;    
   
    private void FixedUpdate()
    {
        Move(_head.transform.position + _head.transform.forward * _speedMove);
        Rotate();
        
    }
    

    private void Move(Vector3 nextPosition)
    {
        Vector3 previusPosition = _head.transform.position;
        Quaternion previusRotate = _head.transform.rotation;
        foreach (var tail in _tails)
        {
            Vector3 tempPosition = tail.transform.position;
            Quaternion tempRotate = tail.transform.rotation;
            tail.transform.position = Vector3.Lerp(tail.transform.position, previusPosition,
                _tailSpringles );
            tail.transform.rotation = Quaternion.Lerp(tail.transform.rotation,
                previusRotate,_tailSpringles );
            
            previusPosition = tempPosition;
            previusRotate = tempRotate;
        }
        _head.Move(nextPosition);
    }

    private void Rotate()
    {
        _angel = Input.GetAxis("Horizontal") * _speedRotation;
        _head.Rotate(_angel);
    }

   
}
