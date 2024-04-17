using System;
using System.Collections;
using System.Collections.Generic;
using Core.RoomSystem;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoseAnimation : MonoBehaviour
{
   [SerializeField] private Image img;
   [SerializeField] private Color def;

   private void Start()
   {
      img.color = def;
     
   }

   /*private void OnEnable()
   {
      RoomController.LoseAction += Fade;
      AgressBar.LoseAct += Fade;
   }*/

   /*private void OnDisable()
   {
      RoomController.LoseAction -= Fade;
      AgressBar.LoseAct -= Fade;
   }*/

   void Fade()
   {
      
      img.DOFade(1, 1);
   }
}
