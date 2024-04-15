using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnterHall : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private int timeOfFade;

    [SerializeField] private Color defaultColor;
    
    private void OnEnable()
    {
        panel.transform.GetComponent<Image>().color = defaultColor;
       EnteringRoom();
    }

    

    private void EnteringRoom()
    {
        
       
        panel.transform.GetComponent<Image>().DOFade(0, timeOfFade);
        //Debug.Log("done");
    }

}
