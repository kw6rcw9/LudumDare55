using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class AgressBar : MonoBehaviour
{
   [SerializeField] private float defaultDamage;
   [field: SerializeField] public float SpeedOfFilling { get; private set; }
   public float MaxAmount { get; private set; } = 1;
   public float CurrentAmount { get; private set; }

   [SerializeField] private float heal;
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
   
}
