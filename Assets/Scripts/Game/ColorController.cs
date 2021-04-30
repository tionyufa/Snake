using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorController : MonoBehaviour
{
    public static ColorController Singleton { get; private set; }
    [SerializeField] private List<Material> _materials;
    private Material _goodMaterial;
    private Material _badMateral;
    private int _currentMaterial;
    private void Awake()
    {
        Singleton = this;
        RandomMaterial();
        _badMateral = _materials[0];
    }

    public void RandomMaterial()
    {
        var random = Random.Range(0, _materials.Count);
        if (random == _currentMaterial)
        {
            RandomMaterial();
        }
        _currentMaterial = random;
        _goodMaterial = _materials[random];
        
    }
    public Material GetGoodMaterial()  
    {
       return _goodMaterial;
    }

    public Material GetBadMaterial()
    {
        var random = Random.Range(0, _materials.Count);
        if (random == _currentMaterial)
        {
            GetBadMaterial();
        }
        
        else
        {
            _badMateral = _materials[random];
        }
        return _badMateral;
    }
    
}
