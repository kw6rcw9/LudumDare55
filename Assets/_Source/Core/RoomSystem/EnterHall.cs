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
    
    private Tween yep;
    private void OnEnable()
    {
        
        panel.transform.GetComponent<Image>().color = defaultColor;
        Debug.Log(panel.transform.GetComponent<Image>().color);
       EnteringRoom();
    }

    private void OnDisable()
    {
        if (yep != null)
        {
            yep.Rewind();
        }
    }

    private void EnteringRoom()
    {
        yep = panel.transform.GetComponent<Image>().DOFade(0, timeOfFade);
     
        Debug.Log("enter hall");
        Debug.Log(panel.transform.GetComponent<Image>().color);
    }

}
