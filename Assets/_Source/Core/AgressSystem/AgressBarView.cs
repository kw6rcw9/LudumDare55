using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AgressBarView : MonoBehaviour
{
    [SerializeField] private Image healthBarImage;
    [SerializeField] private Canvas healthBar;
    public Canvas HealthBar => healthBar;
    private AgressBar _bar;

    [Inject]
    private void Construct(AgressBar bar)
    {
        _bar = bar;
    }
 

    private void OnEnable()
    {
        
        healthBarImage.fillAmount = 0;
        //healthBarImage.color = Color.green;
       
        AgressBar.UpdateBar += UpdateHealthBar;

    }

    private void OnDisable()
    {
        AgressBar.UpdateBar -= UpdateHealthBar;
    }

  

    public void UpdateHealthBar()
    {
        float duration = 0.75f * (_bar.CurrentAmount / _bar.MaxAmount);
        float num = _bar.CurrentAmount / _bar.MaxAmount;
        Debug.Log(num);
        healthBarImage.DOFillAmount( num, _bar.SpeedOfFilling );
        
    }
}
