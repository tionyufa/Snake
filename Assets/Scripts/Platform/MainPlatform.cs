using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainPlatform : MonoBehaviour
{
   [SerializeField] private List<Transform> _pointPeople;
   [SerializeField] private List<Transform> _pointTrap;
   [SerializeField] private PeopleControl _people;
   [SerializeField] private List<GameObject>  _traps;
   [SerializeField] private List<ParticleSystem> _psChangeColor;
   private void Start()
   {
      ColorController.Singleton.RandomMaterial();
      
      for (int i = 0; i < _pointPeople.Count; i++)
      {
          var people = Instantiate(_people, _pointPeople[i].position,Quaternion.identity);
          Destroy(people.gameObject,15f);
          if (i % 2 == 0)
         {
            people.GoodChangeColor();
         }
         else
         {
           people.BadChangeColor();
         }
      }

      for (int i = 0; i < _pointTrap.Count; i++)
      {
         int randomTrap = Random.Range(0, _traps.Count);
         var trap = Instantiate(_traps[randomTrap], _pointTrap[i].position, Quaternion.identity);
         Destroy(trap.gameObject,15f);
      }

      foreach (var ps in _psChangeColor)
      {
         ps.GetComponent<Renderer>().material = ColorController.Singleton.GetGoodMaterial();
      }
     
   }

   
   
}
