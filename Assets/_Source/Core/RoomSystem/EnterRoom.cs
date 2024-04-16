using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class EnterRoom : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private int timeOfFade; 
    private void OnEnable()
    {
        EnteringRoom();
    }

    private void EnteringRoom()
    {
        
       
        panel.transform.GetComponent<Image>().DOFade(0, timeOfFade);
        //Debug.Log("done");
    }
    
}
