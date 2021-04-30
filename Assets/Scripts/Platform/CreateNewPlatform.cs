using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewPlatform : MonoBehaviour
{
   [SerializeField] private MainPlatform _mainPlatform;
   
   private void OnTriggerEnter(Collider other)
   {
      Vector3 positionPlatform = new Vector3(0, 0,  Manager.Singleton.Distation());
     var cube = Instantiate(_mainPlatform, positionPlatform, Quaternion.Euler(0f,0,0f));
      Destroy(cube.gameObject,15f);
      
   }

   
   
}
