using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnterRoom : MonoBehaviour
{
    //[SerializeField] private Color color;
    private void OnEnable()
    {
        EnteringRoom();
    }

    private void EnteringRoom()
    {
        
       
        transform.GetComponent<SpriteRenderer>().DOFade(1, 10);
        Debug.Log("done");
    }
    
}
