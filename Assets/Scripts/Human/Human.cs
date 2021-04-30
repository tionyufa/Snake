using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private bool _eat;
    
    public void EatIs (bool _isEat)
    {
        _eat = _isEat;
    }

    public bool IsEat()
    {
        return _eat;
    }
}
