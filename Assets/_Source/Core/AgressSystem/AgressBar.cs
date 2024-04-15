using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AgressBar : MonoBehaviour
{
   [SerializeField] private float defaultDamage;
   [field: SerializeField] public float SpeedOfFilling { get; private set; }
   public float MaxAmount { get; private set; } = 1;
   public float CurrentAmount { get; private set; }

   [SerializeField] private float heal;
   [SerializeField] private GameObject healthBarBorder;
   public static Action UpdateBar;

   public void TakeDamage()
   {
      CurrentAmount += defaultDamage;
      if (CurrentAmount >= MaxAmount)
      {
         CurrentAmount = MaxAmount;
         UpdateBar?.Invoke();
         Invoke("Lose", 2f);
      }
      if (CurrentAmount >= MaxAmount/3*2)
      {

      }
    Vector3 scale = new Vector3(1f, 1.3f, 1f);
    healthBarBorder.GetComponent<Image>().color = new Color32(160, 0, 0, 255);
    healthBarBorder.transform.DOScale(scale, 0.1f).SetEase(Ease.InOutSine).OnComplete(returnNormalScale);
    UpdateBar?.Invoke();
    
   }

   public void Heal()
   {
      CurrentAmount -= heal;
      if (CurrentAmount <= 0)
      {
         CurrentAmount = 0;
      }
      UpdateBar?.Invoke();
   }

   public void Lose()
   {
      Game.Lose();
   }
   
    void returnNormalScale() {
        Vector3 scale = new Vector3(1f, 1f, 1f);
        healthBarBorder.transform.DOScale(scale, 0.15f);
        healthBarBorder.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    void Start() {
        Invoke("TakeDamage", 3f);
    }
}
