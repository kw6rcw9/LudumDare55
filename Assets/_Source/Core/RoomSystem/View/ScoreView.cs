using System;
using System.Collections;
using System.Collections.Generic;
using Core.RoomSystem;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
   [SerializeField] private TMP_Text score;

   private void OnEnable()
   {
      TaskScore.ApdateScore += UpdateScore;
   }

   private void OnDisable()
   {
      TaskScore.ApdateScore -= UpdateScore;
   }

   private void UpdateScore(int score1)
   {
      score.text = score1.ToString();
   }
}
