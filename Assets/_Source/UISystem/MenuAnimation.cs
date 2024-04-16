using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField] private Image diablo;
    [SerializeField] private Image lightD;
    [SerializeField] private float speed;

    private void Awake()
    {
        AnimDFadeIn();
    }

    private void AnimDFadeIn()
    {
        
        diablo.DOFade(1, speed)
            .SetEase(Ease.InFlash)
            .OnComplete(AnimDFadeOut);
        
    }
    private void AnimDFadeOut()
    {
        
        diablo.DOFade(0, speed)
            .SetEase(Ease.OutFlash)
            .OnComplete(AnimLFadeIn);
    }
    private void AnimLFadeIn()
    {
        
        lightD.DOFade(1, speed)
            .SetEase(Ease.InFlash)
            .OnComplete(AnimLFadeOut);
        
    }
    private void AnimLFadeOut()
    {
        
        lightD.DOFade(0, speed)
            .SetEase(Ease.OutFlash)
            .OnComplete(AnimDFadeIn);
       
    }
}
