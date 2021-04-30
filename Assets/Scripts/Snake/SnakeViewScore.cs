using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SnakeViewScore : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _textScore;
   private SnakeHead _head;
   private int _index;
   private float _textup;
  

   private void Awake()
   {
      _head = GetComponent<SnakeHead>();
   }

   private void OnEnable()
   {
      _head.UpdateScore += OnScoreKill;
   }

   private void OnDisable()
   {
      _head.UpdateScore -= OnScoreKill;
   }

   private void OnScoreKill(int score)
   {
      
      _textScore.text = String.Format("Score: " + score);
   }

}
