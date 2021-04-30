using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
   public static Manager Singleton { get; private set; }
   private int _distation = -25;
   private void Awake()
   {
      Singleton = this;
      Time.timeScale = 1f;
   }

   public int Distation()
   {
      _distation += 100; //Добавляем размер платформы
      return _distation;
   }
}
