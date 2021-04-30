using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleControl : MonoBehaviour
{
   [SerializeField] private List<Human> _humans;
   [SerializeField] private List<SkinnedMeshRenderer> _meshRenderers;
   

   public void GoodChangeColor()
   {
      var colorGood = ColorController.Singleton.GetGoodMaterial();
      for (int i = 0; i < _meshRenderers.Count; i++)
      {
         _meshRenderers[i].material = colorGood;
         _humans[i].EatIs(true);

      }
   }

   public void BadChangeColor()
   {
      var colorBad = ColorController.Singleton.GetBadMaterial();
      for (int i = 0; i < _meshRenderers.Count; i++)
      {
         _meshRenderers[i].material = colorBad;
         _humans[i].EatIs(false);

      }
     
   }
}
